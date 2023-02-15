using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labyrinthe
{
    internal class Maze
    {
        public static int ECRAN = 900;  //grandeur d'ecran
        public static int N = 65535;  // infinity
        public int minSteps = N;
        public int CurrentSteps = 0;
        public int nbrVisite = 1;
        public int rows;
        public int cols;
        public Carre[,] map;
        public int[,] wallH;
        public int[,] wallV;
        public CarreFile<Carre> carreFile = new CarreFile<Carre>(); // structure file
		public MinPriorityQueue tryPoints; // priority queue pour A*
        public Carre jouerCarre;
		public static Random rd = new Random();
        public static int[] dx = { 1, 0, -1, 0 }; //décalage des coordonnées de l'axe s x sur l'axe  y
        public static int[] dy = { 0, 1, 0, -1 };
        public static int[] dwx = { 1, 0, 0, 0 };
        public static int[] dwy = { 0, 1, 0, 0 };
        public int width; // taille de chaque carrée
        public int height;
		public static Pen redPen = new Pen(Color.Red, 4); // crayon pour peindre les murs
		public static Pen greyPen = new Pen(Color.LightGray, 1);
		public static SolidBrush whiteBrush = new SolidBrush(Color.White); //caryon pour peindre les carrées
		public static SolidBrush greenBrush = new SolidBrush(Color.Green);
		public static SolidBrush blueBrush = new SolidBrush(Color.Blue);
		public static SolidBrush blackBrush = new SolidBrush(Color.Black);
		public static SolidBrush orangeBrush = new SolidBrush(Color.Orange);
		public static SolidBrush goldBrush = new SolidBrush(Color.Gold);
        public static SolidBrush[] brushs = {whiteBrush, greenBrush, blueBrush, blackBrush, orangeBrush, goldBrush};
        public bool jouerModel = false;


		public Maze(int rows, int cols)
        {
            // initialiser labyrinthe selon nombre choisi par joueur
            this.rows = rows;
            this.cols = cols;
            this.map = new Carre[rows, cols];
            this.wallH = new int[rows + 1, cols];
            this.wallV = new int[rows, cols + 1];
			this.width = ECRAN / cols;
			this.height = ECRAN / rows;
			setCarre();
            setWallH();
            setWallV();
            blockDigui(); //gerer les murs aléatoirement
            
        }

        public void setCarre()
        {

            //initialiser les nodes(carrées) 
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {

                    // heuristique = (cols + rows - i - j - 2)
                    //this.map[i, j] = new Carre(x, y, cout, heuristique/manhattan, Status.vide)
                    int cout = N;
                    int axeX = j;
                    int axeY = i;
                    Carre parent = null;
                    int heuristique = cols + rows - i - j - 2;
                    this.map[i, j] = new Carre(axeX, axeY, cout, parent, heuristique, Status.vide);
                }
            }
            // mettre le "start" comme step=0, status="visited"
            map[0, 0].status = Status.visited;
            map[0, 0].step = 0;


        }
        // initialiser les murs horizontaux et virticaux 
        // tous les murs peuvent être traversés sauf ceux situés au périmètre
        public void setWallH()
        {
            for (int i = 0; i < rows + 1; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0 || i == rows)
                    {
                        wallH[i, j] = 1;
                    }
                    else
                    {
                        wallH[i, j] = 0;
                    }
                }
            }
        }
        public void setWallV()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols + 1; j++)
                {
                    if (j == 0 || j == cols)
                    {
                        wallV[i, j] = 1;
                    }
                    else
                    {
                        wallV[i, j] = 0;
                    }
                }
            }
        }
        public void blockDigui()
        {
            blockDigui(0, 0, cols - 1, rows - 1);
        }
        public void blockDigui(int x1, int y1, int x2, int y2)
        {
            //si le block est trop petit, on s'arrete
            if (x2 - x1 < 2 || y2 - y1 < 2)
            {
                return;
            }
            //separer à 4 blocks aléatoirement
            int xM = rd.Next(x1 + 2, x2 + 1);
            int yM = rd.Next(y1 + 2, y2 + 1);
            //mur horizonal
            for (int i = x1; i < x2 + 1; i++)
            {
                wallH[yM, i] = 1;
            }
            // mur virtical
            for (int i = y1; i < y2 + 1; i++)
            {
                wallV[i, xM] = 1;
            }
            // creuser 3 trous pour assurer qu'on peut aller 4 blocks
            int xHole1 = rd.Next(x1, xM);
            int xHole2 = rd.Next(xM, x2 + 1);
            int yHole = rd.Next(y1, yM);
            wallH[yM, xHole1] = 0;
            wallH[yM, xHole2] = 0;
            wallV[yHole, xM] = 0;
            // faire résursion
            blockDigui(x1, y1, xM - 1, yM - 1);
            blockDigui(xM, y1, x2, yM - 1);
            blockDigui(x1, yM, xM - 1, y2);
            blockDigui(xM, yM, x2, y2);

        }

        // pentre labyrinthe
        public void DrawSelf()
        {
			
			DrawCarres();
			DrawWalls();
            if (jouerModel) DrawJouer();
            DrawScore();
        }

        public void DrawJouer()
        {
			Rectangle rectangle = new Rectangle(jouerCarre.x * width, jouerCarre.y * height, width, height);
			GameFramwork.g.FillRectangle(brushs[(int)jouerCarre.status], rectangle);
		}
		public void DrawScore()
        {
			GameFramwork.g.DrawString($"Minimal step: {GameObjectManager.maze.minSteps}", new Font("Arial", 12), new SolidBrush(Color.DarkOrange), new Point(950, 100));
			GameFramwork.g.DrawString($"Current step: {GameObjectManager.maze.CurrentSteps}", new Font("Arial", 12), new SolidBrush(Color.DarkGreen), new Point(950, 150));
			GameFramwork.g.DrawString($"Carrés visitées: {GameObjectManager.maze.nbrVisite}", new Font("Arial", 12), new SolidBrush(Color.DarkBlue), new Point(950, 200));
		}
        //peindre carrées selon leur état
        public void DrawCarres()
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    Rectangle rectangle = new Rectangle(j * width, i * height, width, height);
                    GameFramwork.g.FillRectangle(brushs[(int)map[i, j].status], rectangle);
                }
            }

        }
        public void DrawWalls()
        {
            // draw wall horizantal
			for (int i = 0; i < rows + 1; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					GameFramwork.g.DrawLine(greyPen, new Point(j * width, i * height), new Point((j + 1) * width, i * height));

					if (wallH[i, j] == 1)
                    {
						GameFramwork.g.DrawLine(redPen, new Point(j * width, i * height), new Point((j + 1) * width, i * height));
					}
				}
			}
            // draw wall virtical
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols + 1; j++)
				{
					GameFramwork.g.DrawLine(greyPen, new Point(j * width, i * height), new Point((j) * width, (i + 1) * height));
					if (wallV[i, j] == 1)
                    {
						GameFramwork.g.DrawLine(redPen, new Point(j * width, i * height), new Point((j) * width, (i + 1) * height));
					}
				}
			}
		}
        //peindre le meilleur chemin
		public void drawPath(Carre carre)
		{
			while (carre != null)
            {
				map[carre.y, carre.x].status = Status.meilleur;
				carre = carre.pre;
			}
            
		}

        // pour l'algorithme DFS, le meilleur chemin est sauvgardée dans une file
        public void drawPathDFS()
        {
            Carre carreCurrent;
            while((carreCurrent = carreFile.pop()) != null)
            {
                map[carreCurrent.y, carreCurrent.x].status = Status.meilleur;
            }
        }
		public void dfs()
		{
			nbrVisite = 1;
			dfs(0, 0);
            drawPathDFS();
        }
		public void dfs(int x, int y)
		{
            // si labyrinthe est trop grand on sleep pas
            if(cols <= 300 && rows <= 300) Thread.Sleep(1);
            Carre carreCurrent = map[y, x];
            CurrentSteps = carreCurrent.step;
            // si carrée currante == sortir et le chemin est plus court que la derrière fois, on arrete et mettre le chemin dans file
			if (x == cols - 1 && y == rows - 1)
			{
                if (carreCurrent.step < minSteps)
                {
                    minSteps = carreCurrent.step;
					carreFile.clear();
                    carreFile.push(carreCurrent.copy());
                    while (carreCurrent.pre != null)
                    {
                        carreCurrent = carreCurrent.pre;
                        carreFile.push(carreCurrent.copy());
                    }
                    Console.WriteLine("current best way " + minSteps + " steps================================");
                    return;
                }
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				// verifier les murs a gauche a droite
				
				if (i % 2 == 0)
				{
					if (wallV[carreCurrent.y + dwy[i], carreCurrent.x + dwx[i]] == 0)
					{ //si pas de mur, on continue
						int nextX = carreCurrent.x + dx[i];
						int nextY = carreCurrent.y + dy[i];

						if (map[nextY, nextX].status == Status.vide || (map[nextY, nextX].status == Status.essay && map[nextY, nextX].step > carreCurrent.step + 1))
						{ // si carrée est jamais visitée, ou visitée mais steps plus grand que cette fois, on continue
							if (map[nextY, nextX].status == Status.vide)
							{
								nbrVisite++;
							}
                            // le metttre comme visitée, step + 1, parent node = carree currente
							map[nextY, nextX].status = Status.visited;
							map[nextY, nextX].step = carreCurrent.step + 1;
							map[nextY, nextX].pre = carreCurrent;
                            // faire récursion pour cette carrée
							dfs(nextX, nextY);
							map[nextY, nextX].status = Status.essay;
						}
					}
				}
				else
                {  //verifier les murs en haut et en bas
                    if (wallH[carreCurrent.y + dwy[i], carreCurrent.x + dwx[i]] == 0)
					{ 
						int nextX = carreCurrent.x + dx[i];
						int nextY = carreCurrent.y + dy[i];
					
						if (map[nextY, nextX].status == Status.vide || (map[nextY, nextX].status == Status.essay && map[nextY, nextX].step > carreCurrent.step + 1))
						{ 
							if (map[nextY, nextX].status == Status.vide)
							{
								nbrVisite++;
							}
							
							map[nextY, nextX].status = Status.visited;
							map[nextY, nextX].step = carreCurrent.step + 1;
							map[nextY, nextX].pre = carreCurrent;
							dfs(nextX, nextY);
							map[nextY, nextX].status = Status.essay;
						}
					}
				}
			}
			return;
		}

		public void bfs()
		{
            nbrVisite = 1;
            CurrentSteps = 0;
			bfs(0, 0);

		}
		public void bfs(int x, int y)
		{

			//clear file pour s'assurer il est vide
			carreFile.clear();
            // push "start" dans file
            map[y, x].status = Status.visited;
            carreFile.push(map[y, x]);
            Carre carreCurrent;
			// si la file n'est pas vide, on continue
			while (!carreFile.isEmpty())
			{
                // pop une carrée comme carrée courrente
				carreCurrent = carreFile.pop();
                carreCurrent.status = Status.visited;
                CurrentSteps = carreCurrent.step;
				//si carrée courrent égale "sortir", on s'arrête
				if (carreCurrent.x == cols - 1 && carreCurrent.y == rows - 1)
				{
                    // pour bfs, dès qu'on trouve le chemin, c'est le meilleure chemin
                    // donc on la peint
                    minSteps = carreCurrent.step;
					drawPath(carreCurrent);
					return;
				}
				// tester 4 directions
				for (int i = 0; i < 4; i++)
				{
					if (cols <= 150 && rows <= 150) Thread.Sleep(1);
					//  tester mur horizontal si on bouge à gauche à droite
					if (i % 2 == 0)
					{
						if (wallV[carreCurrent.y + dwy[i], carreCurrent.x + dwx[i]] == 0)
						{ 
                            // continur si le mur prut être traversé
							int nextX = carreCurrent.x + dx[i];
							int nextY = carreCurrent.y + dy[i];
							if (map[nextY,nextX].status == Status.vide)
							{ 
                                // si cette carrée n'est jamais visitée
                                // nombr visite plus 1, modifier son état comme visited
                                // son node parent est carrée courrente
                                // push cette carrée dans la file
                                nbrVisite++;
								map[nextY,nextX].status = Status.essay;
								map[nextY,nextX].step = carreCurrent.step + 1;
								map[nextY,nextX].pre = carreCurrent;
                                carreFile.push(map[nextY, nextX]);
							}
						}
					}
					else
					{  
						if (wallH[carreCurrent.y + dwy[i], carreCurrent.x + dwx[i]] == 0)
						{ 
							int nextX = carreCurrent.x + dx[i];
							int nextY = carreCurrent.y + dy[i];
							if (map[nextY, nextX].status == Status.vide)
							{ 
                                nbrVisite++; 
								map[nextY, nextX].status = Status.essay;
								map[nextY, nextX].step = carreCurrent.step + 1;
								map[nextY, nextX].pre = carreCurrent;
								carreFile.push(map[nextY, nextX]);
							}
						}
					}
				}
			}
           // si la file est vide, c'est à dir qu'il n'y a pas de solution
           // dans notre labyrithe, il y a tousjour au moins une solution
           Console.WriteLine("Pas de chance");
        }

		public void aStar(int sleepTime)
		{
			CurrentSteps = 0;
			minSteps = N;
			nbrVisite = 0;
			aStar(0, 0, sleepTime);
			drawPath(carreFile.pop());
		}
		public void aStar(int x, int y, int sleepTime)
		{
			Carre currentCarre;
            // créer priorityqueue pour y sauvegarder les carrées d'essai
			tryPoints = new MinPriorityQueue(2 * (cols + rows));
			tryPoints.Push(map[y, x]);
			nbrVisite++;
			//pendant que  priorityqueue n'est pas vide
			while (!tryPoints.isEmpty())
			{
                // pop la carrée dont "f" est minimal comme carrée courente 
				 currentCarre = tryPoints.PopMin();
				 CurrentSteps = currentCarre.step;
				if (currentCarre.x == rows - 1 && currentCarre.y == cols - 1)
				{  
                    // si carrée courrente égale à "Sortie", function se termine
                    // on met carrée courrente dans la file, puis répéte pour son parent
					minSteps = currentCarre.step;
					carreFile.clear();
					carreFile.push(currentCarre.copy());
					while (currentCarre.pre != null)
					{
						currentCarre = currentCarre.pre;
						carreFile.push(currentCarre);
					}

					return;
				}
                // si la carrée qu'on vient de pop n'est pas "Sortie", on change son état à "visited" 
				currentCarre.status = Status.visited; 
                // ensuite, on teste les voisins de la carrée courrente
				for (int i = 0; i < 4; i++)
				{
					if (cols <= 150 && rows <= 150) Thread.Sleep(sleepTime);
                    if (i % 2 == 0)
					{
						if (wallV[currentCarre.y + dwy[i], currentCarre.x + dwx[i]] == 0)
						{
							int nextX = currentCarre.x + dx[i];
							int nextY = currentCarre.y + dy[i];
							if (map[nextY, nextX].status == Status.vide)
							{ 
                                // si le voisin n'est jamais visité, on change son état à "essay"
                                // puis le "push" dans priorityqueue, son node parrent égale à carrée courrente
                                // son step(c) et totalDistance(f) vont être mises-à-jour
								Carre nextTry = map[nextY, nextX];
								nextTry.status = Status.essay;
								nextTry.step = currentCarre.step + 1;
								nextTry.pre = currentCarre;
								nextTry.totalDistance = nextTry.step + nextTry.distanceTobe;
								tryPoints.Push(nextTry);
								nbrVisite++;
							}
						}
					}
					else
					{  
						if (wallH[currentCarre.y + dwy[i], currentCarre.x + dwx[i]] == 0)
						{ 
							int nextX = currentCarre.x + dx[i];
							int nextY = currentCarre.y + dy[i];
							if (map[nextY, nextX].status == Status.vide)
							{ 
								Carre nextTry = map[nextY, nextX];
								nextTry.status = Status.essay; 
								nextTry.step = currentCarre.step + 1;
								nextTry.pre = currentCarre;
								nextTry.totalDistance = nextTry.step + nextTry.distanceTobe;
								tryPoints.Push(nextTry);
								nbrVisite++;
							}
						}
					}
				}
			}
		}

        // une autre façon de DFS qui s'arrête dès qu'on trouve le chemin pour la première fois
        public void setWay()
        {
            CurrentSteps = 0;
            minSteps = N;
            nbrVisite = 0;
            map[0, 0].status = Status.vide;
            setWay(0, 0);
        }
        public bool setWay(int x, int y)
        {
            if (cols <= 150 && rows <= 150) Thread.Sleep(1);
            if (cols <= 100 && rows <= 100) Thread.Sleep(1);
			CurrentSteps++;
            if (map[rows - 1, cols - 1].status == Status.visited)
            {
				// si carrée courrente égale à "Sortie", function se termine
                // on compte toute les carrées dont l'état est "visited", puis le change à "meilleur"
				Carre currentCarre = map[rows - 1, cols - 1];
                minSteps = 0;
               for(int i = 0; i < rows; i++)
                {
                    for(int j = 0; j < cols; j++)
                    {
                        if (map[i, j].status == Status.visited)
                        {
                            minSteps++;
                            map[i, j].status = Status.meilleur;
                        }
                    }
                }
                return true;
            }
            // si non, et la carrée n'est jamais visitée, on met son état comme "visited"
            if (map[y, x].status == Status.vide)
            {
                map[y, x].status = Status.visited;
                nbrVisite++;
				// ensuite  si la mur peut être traversé, on vérifie ses voisins de 4 directions de façon recursive
				if (wallH[y + 1, x] != 1)
                {
                    map[y + 1, x].step = map[y, x].step + 1;
             
					if (setWay(x, y + 1)) 
					{
						map[y + 1, x].pre = map[y, x];
                        return true;
                    } 
                }
                if (wallV[y, x + 1] != 1)
                {
                    map[y, x + 1].step = map[y, x].step + 1;
                    if (setWay(x + 1, y))
                    {
                        map[y, x + 1].pre = map[y, x];
                        return true;
                    }
                }
                if (wallH[y, x] != 1)
                {
                    map[y - 1, x].step = map[y, x].step + 1;
                    if (setWay(x, y - 1))
                    {
                        map[y - 1, x].pre = map[y, x];
                        return true;
                    }
                }
                if (wallV[y, x] != 1)
                {
                    map[y, x - 1].step = map[y, x].step + 1;
                    if (setWay(x - 1, y))
                    {
                        map[y, x - 1].pre = map[y, x];
                        return true;
                    }
                }
                // si dans les 4 directions, function récursion returne toujours false, on considère cette carrée comme le point "mort"
                map[y,x].status = Status.mort;
                return false;
            }
            else
            {
                return false;
            }
        }

        // mode manuel
        public void Manuel()
        {
            Console.WriteLine("game");
            jouerModel = true;
            // créer carrée du joueur
            jouerCarre = new Carre(0, 0, 0, null);
            jouerCarre.status = Status.manuel;
            CurrentSteps = 0;
            nbrVisite = 0;
        }

        //carrée du joueur bouge selon événement du clavier et la situation du mur
        public void KeyDown(KeyEventArgs e)
        {
            if (jouerModel)
            {
				int X = jouerCarre.x;
				int Y = jouerCarre.y;
                map[Y, X].status = Status.manuel;
				if (jouerModel)
				{
					switch (e.KeyCode)
					{
						case Keys.Up:
							if (wallH[Y, X] == 0)
                            {
                                CurrentSteps++;
								jouerCarre.y--;
                                nbrVisite++;
								map[Y, X].status = Status.visited;
								SoundManager.PlayMove();
							} else
                            {
                                SoundManager.PlayBlock();
                            }
								
							break;
						case Keys.Down:
							if (wallH[Y + 1, X] == 0)
                            {
                                CurrentSteps++;
								jouerCarre.y++;
								nbrVisite++;
								map[Y, X].status = Status.visited;
								SoundManager.PlayMove();
							}
							else
							{
								SoundManager.PlayBlock();
							}
							break;
						case Keys.Right:
							if (wallV[Y, X + 1] == 0)
							{
								CurrentSteps++;
								jouerCarre.x++;
								nbrVisite++;
								map[Y, X].status = Status.visited;
								SoundManager.PlayMove();
							}
							else
							{
								SoundManager.PlayBlock();
							}
							break;
						case Keys.Left:
							if (wallV[Y, X] == 0)
							{
								CurrentSteps++;
								jouerCarre.x--;
								nbrVisite++;
								map[Y, X].status = Status.visited;
								SoundManager.PlayMove();
							}
							else
							{
								SoundManager.PlayBlock();
							}
							break;
					}
                    if (jouerCarre.x == cols - 1 && jouerCarre.y == rows - 1)
                    {
                        map[rows - 1, cols - 1].status = Status.manuel;
                        minSteps = CurrentSteps;
                        jouerModel = false;
                    }
				}
			}
        }

        // ancien code pour sauvegarder labyrinthe dans fichier
		public void SaveWall()
        {
            SaveWallH();
            SaveWallV();
        }
        public void LoadWall()
        {
            LoadWallH();
            LoadWallV();
        }

        public void SaveWallH()
        {
            using (StreamWriter sw = new StreamWriter("C:\\Users\\e2194517\\Documents\\GitHub\\labo3Algo\\WallH.txt"))
            {
                sw.WriteLine(rows);
                sw.WriteLine(cols);
                for (int i = 0; i <= rows; i++)
                {
                    for(int j = 0; j < cols; j++)
                    {
                        sw.WriteLine(wallH[i, j]);
                    }
                }
            }
        }
        public void SaveWallV()
        {
            using (StreamWriter sw = new StreamWriter("C:\\Users\\e2194517\\Documents\\GitHub\\labo3Algo\\WallV.txt"))
            {
                sw.WriteLine(rows);
                sw.WriteLine(cols);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j <= cols; j++)
                    {
                        sw.WriteLine(wallV[i, j]);
                    }
                }
            }
        }
		// ancien code pour charger labyrinthe du fichier
		public void LoadWallH()
        {
            try
            {
                // créer StreamReader instance pour lire fichier 
                using (StreamReader sr = new StreamReader("C:\\Users\\e2194517\\Documents\\GitHub\\labo3Algo\\WallH.txt"))
                {
                    rows = Convert.ToInt32(sr.ReadLine());
                    cols = Convert.ToInt32(sr.ReadLine());
                    // sur head du fichier on peut savois nombres des colonnes et lignes
                    for (int i = 0; i <= rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            wallH[i, j] = Convert.ToInt32(sr.ReadLine());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        public void LoadWallV()
        {
            try
            {
                using (StreamReader sr = new StreamReader("C:\\Users\\e2194517\\Documents\\GitHub\\labo3Algo\\WallV.txt"))
                {
                    rows = Convert.ToInt32(sr.ReadLine());
                    cols = Convert.ToInt32(sr.ReadLine());
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j <= cols; j++)
                        {
                            wallV[i, j] = Convert.ToInt32(sr.ReadLine());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
