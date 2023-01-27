using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace labyrinthe
{
    internal class Maze
    {
        public static int ECRAN = 900;
        public static int N = 65535;
        public int minSteps = N;
        public int CurrentSteps = 0;
        public int nbrVisite = 1;
        public int rows;
        public int cols;
        public Carre[,] map;
        public int[,] wallH;
        public int[,] wallV;
        public CarreFile<Carre> carreFile = new CarreFile<Carre>();
		public MinPriorityQueue tryPoints;
		public static Random rd = new Random();
        public static int times;
        public static int[] dx = { 1, 0, -1, 0 };
        public static int[] dy = { 0, 1, 0, -1 };
        public static int[] dwx = { 1, 0, 0, 0 };
        public static int[] dwy = { 0, 1, 0, 0 };
        public int width;
        public int height;
		public static Pen redPen = new Pen(Color.Red, 2);
		public static Pen greyPen = new Pen(Color.LightGray, 1);
		public static SolidBrush whiteBrush = new SolidBrush(Color.White);
		public static SolidBrush greenBrush = new SolidBrush(Color.Green);
		public static SolidBrush blueBrush = new SolidBrush(Color.Blue);
		public static SolidBrush blackBrush = new SolidBrush(Color.Black);
		public static SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        public static SolidBrush[] brushs = {whiteBrush, greenBrush, blueBrush, blackBrush, orangeBrush};
        


		public Maze(int rows, int cols)
        {
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
            blockDigui();
            
        }

        public void setCarre()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    this.map[i, j] = new Carre(j, i, N, null, (cols + rows - i - j - 2), Status.vide);
                }
            }
            map[0, 0].status = Status.visited;
            map[0, 0].step = 0;


			//map[cols - 1, rows - 1].status = Status.meilleur;
        }

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
            //分格过小则退出
            if (x2 - x1 < 2 || y2 - y1 < 2)
            {
                return;
            }
            //随机取横竖分割线
            int xM = rd.Next(x1 + 2, x2 + 1);
            int yM = rd.Next(y1 + 2, y2 + 1);
            //分格地图
            //横分割线
            for (int i = x1; i < x2 + 1; i++)
            {
                wallH[yM, i] = 1;
            }
            // 竖分割线
            for (int i = y1; i < y2 + 1; i++)
            {
                wallV[i, xM] = 1;
            }
            // 在分隔线上挖3个洞
            int xHole1 = rd.Next(x1, xM);
            int xHole2 = rd.Next(xM, x2 + 1);
            int yHole = rd.Next(y1, yM);
            wallH[yM, xHole1] = 0;
            wallH[yM, xHole2] = 0;
            wallV[yHole, xM] = 0;
            // 递归调用在分区块内制造路障
            blockDigui(x1, y1, xM - 1, yM - 1);
            blockDigui(xM, y1, x2, yM - 1);
            blockDigui(x1, yM, xM - 1, y2);
            blockDigui(xM, yM, x2, y2);

        }

        public void DrawSelf()
        {
            DrawCarres();
            DrawWalls();
            DrawScore();

        }
        public void DrawScore()
        {
			GameFramwork.g.DrawString($"Minimal step: {GameObjectManager.maze.minSteps}", new Font("Arial", 12), new SolidBrush(Color.DarkOrange), new Point(950, 100));
			GameFramwork.g.DrawString($"Current step: {GameObjectManager.maze.CurrentSteps}", new Font("Arial", 12), new SolidBrush(Color.DarkGreen), new Point(950, 150));
			GameFramwork.g.DrawString($"Carrés visitées: {GameObjectManager.maze.nbrVisite}", new Font("Arial", 12), new SolidBrush(Color.DarkBlue), new Point(950, 200));
		}
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

		public void drawPath(Carre carre)
		{
			while (carre != null)
            {
				map[carre.y, carre.x].status = Status.meilleur;
				carre = carre.pre;
			}
            
		}
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
            //Thread.Sleep(1000 / 200);
            //Console.WriteLine($"dfs  x{x} y{y}  col{cols} row{rows} {x == cols - 1 && y == rows - 1}");
            Carre carreCurrent = map[y, x];
            CurrentSteps = carreCurrent.step;
			if (x == cols - 1 && y == rows - 1)
			{
                //Console.WriteLine($"minSteps: {minSteps}");
                //Console.WriteLine($"CurrenSteps: {carreCurrent.step}");
                //Thread.Sleep(1000/12);
                if (carreCurrent.step < minSteps)
                {
                    minSteps = carreCurrent.step;
                    
					//Console.WriteLine($"minSteps: {minSteps}");
					//Thread.Sleep(1000);
					carreFile.clear();
                    carreFile.push(carreCurrent.copy());
                    while (carreCurrent.pre != null)
                    {
                        carreCurrent = carreCurrent.pre;
                        carreFile.push(carreCurrent.copy());
                    }
                    Console.WriteLine(minSteps + " steps===========================================================");
                    return;
                }
    //            carreFile.clear();
				//carreFile.push(carreCurrent.copy());
				//while (carreCurrent.pre != null)
				//{
				//	carreCurrent = carreCurrent.pre;
				//	carreFile.push(carreCurrent);
				//}
				//Console.WriteLine(minSteps + " steps");
				return;
			}
			//Console.WriteLine($"Current case: {carreCurrent.ToString()}");
			for (int i = 0; i < 4; i++)
			{
				//                如果左右方向就检测垂直墙
				
				if (i % 2 == 0)
				{
                    //Console.WriteLine($"WV: x-{carreCurrent.x + dwx[i]} y-{carreCurrent.y + dwy[i]} ");
                    //Console.WriteLine(wallV[carreCurrent.y + dwy[i], carreCurrent.x + dwx[i]]);
					if (wallV[carreCurrent.y + dwy[i], carreCurrent.x + dwx[i]] == 0)
					{ //墙为空则继续试探
						int nextX = carreCurrent.x + dx[i];
						int nextY = carreCurrent.y + dy[i];
                        //Console.WriteLine($"nextY: {nextY}, nextX: {nextX}");
						if (map[nextY, nextX].status == Status.vide || map[nextY, nextX].status == Status.essay)
						{ // 如果未被试探过
                            if (map[nextY, nextX].status == Status.vide)
                            {
                                nbrVisite++;
                            }
							map[nextY, nextX].status = Status.visited;
							map[nextY, nextX].step = carreCurrent.step + 1;
							map[nextY, nextX].pre = carreCurrent;
                            //Console.WriteLine($"next case: { map[nextY, nextX].ToString()}");
							dfs(nextX, nextY);
							map[nextY, nextX].status = Status.essay;
						}
					}
				}
				else
				{  //上下方法,检测水平墙
					//Console.WriteLine($"WH: {carreCurrent.y + dwy[i]}: {carreCurrent.x + dwx[i]}");
					//Console.WriteLine(wallH[carreCurrent.y + dwy[i], carreCurrent.x + dwx[i]]);
					if (wallH[carreCurrent.y + dwy[i], carreCurrent.x + dwx[i]] == 0)
					{ //墙为空则继续试探
						int nextX = carreCurrent.x + dx[i];
						int nextY = carreCurrent.y + dy[i];
					
						//Console.WriteLine($"nextY: {nextY}, nextX: {nextX}");
						if (map[nextY, nextX].status == Status.vide || map[nextY, nextX].status == Status.essay)
						{ // 如果未被试探过
							if (map[nextY, nextX].status == Status.vide)
							{
								nbrVisite++;
							}
							map[nextY, nextX].status = Status.visited;
							map[nextY, nextX].step = carreCurrent.step + 1;
							map[nextY, nextX].pre = carreCurrent;
							//Console.WriteLine($"next case: {map[nextY, nextX].ToString()}");
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
			//定义右下上左格子和墙的位移变量

			//创建队列保存需要对周边探索的点 *将file提到成员变量级别一遍其他函数调用, 寻找之前清空
			carreFile.clear();
            // 将起点压入队列,并置为已访问
            map[y, x].status = Status.visited;
            carreFile.push(map[y, x]);
            Carre carreCurrent;
			// 如果队列不为空则继续搜索
			while (!carreFile.isEmpty())
			{
				//int currentX = file.peak().x;
				//int currentY = file.peak().y;
				//int currentStep = file.peak().step;
				carreCurrent = carreFile.pop();
                CurrentSteps = carreCurrent.step;
				//如果当前节点为出口,则返回,并打印步数
				if (carreCurrent.x == cols - 1 && carreCurrent.y == rows - 1)
				{
                    minSteps = carreCurrent.step;
					drawPath(carreCurrent);
					return;
				}
				// 向四个方向试探 i = 0..3 代表右下左上
				for (int i = 0; i < 4; i++)
				{
                    Thread.Sleep(1);
                    //                如果左右方向就检测垂直墙
                    if (i % 2 == 0)
					{
						if (wallV[carreCurrent.y + dwy[i], carreCurrent.x + dwx[i]] == 0)
						{ //墙为空则继续试探
							int nextX = carreCurrent.x + dx[i];
							int nextY = carreCurrent.y + dy[i];
							if (map[nextY,nextX].status == Status.vide)
							{ // 如果未被试探过
                                nbrVisite++;
								map[nextY,nextX].status = Status.visited;
								map[nextY,nextX].step = carreCurrent.step + 1;
								map[nextY,nextX].pre = carreCurrent;
                                carreFile.push(map[nextY, nextX]);
							}
						}
					}
					else
					{  //上下方法,检测水平墙
						if (wallH[carreCurrent.y + dwy[i], carreCurrent.x + dwx[i]] == 0)
						{ //墙为空则继续试探
							int nextX = carreCurrent.x + dx[i];
							int nextY = carreCurrent.y + dy[i];
							if (map[nextY, nextX].status == Status.vide)
							{ // 如果未被试探过
                                nbrVisite++; 
								map[nextY, nextX].status = Status.visited;
								map[nextY, nextX].step = carreCurrent.step + 1;
								map[nextY, nextX].pre = carreCurrent;
								carreFile.push(map[nextY, nextX]);
							}
						}
					}
				}
				//file.pop();
			}
			//如果队列为空还没有到出口,则显示未找到
			//System.out.println("Pas de chance");
		}

		public void aStar()
		{
			CurrentSteps = 0;
			minSteps = N;
			nbrVisite = 0;
			aStar(0, 0);
			drawPath(carreFile.pop());
		}
		public void aStar(int x, int y)
		{
			Carre currentCarre;
			tryPoints = new MinPriorityQueue(2 * (cols + rows));
			tryPoints.Push(map[y, x]);
			nbrVisite++;
			//A* 算法中我们设定为探索墙为0, 已探索为2, 尝试点为1, 最终路径为3
			while (!tryPoints.isEmpty())
			{
				 currentCarre = tryPoints.PopMin();
				 CurrentSteps = currentCarre.step;
				if (currentCarre.x == rows - 1 && currentCarre.y == cols - 1)
				{  //如果弹出点就是终点, 回溯路径,将路径存入队列file,以便后期绘图,并返回
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
				currentCarre.status = Status.visited; //否则, 将弹出点设为已探索
				//map[currentCarre.y][currentCarre.x].status = Status.visited; //否则, 将弹出点设为已探索
				for (int i = 0; i < 4; i++)
				{
                    Thread.Sleep(1);
                    //                如果左右方向就检测垂直墙
                    if (i % 2 == 0)
					{
						if (wallV[currentCarre.y + dwy[i], currentCarre.x + dwx[i]] == 0)
						{ //墙为空则继续试探
							int nextX = currentCarre.x + dx[i];
							int nextY = currentCarre.y + dy[i];
							if (map[nextY, nextX].status == Status.vide)
							{ // 如果未被试探过
								Carre nextTry = map[nextY, nextX];
								nextTry.status = Status.essay; // 如此点未被探索,则暂时设为尝试点,并压入优先队列
								nextTry.step = currentCarre.step + 1;
								nextTry.pre = currentCarre;
								nextTry.totalDistance = nextTry.step + nextTry.distanceTobe;
								tryPoints.Push(nextTry);
								nbrVisite++;
							}
						}
					}
					else
					{  //上下方法,检测水平墙
						if (wallH[currentCarre.y + dwy[i], currentCarre.x + dwx[i]] == 0)
						{ //墙为空则继续试探
							int nextX = currentCarre.x + dx[i];
							int nextY = currentCarre.y + dy[i];
							if (map[nextY, nextX].status == Status.vide)
							{ // 如果未被试探过
								Carre nextTry = map[nextY, nextX];
								nextTry.status = Status.essay; // 如此点未被探索,则暂时设为尝试点,并压入优先队列
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

	}
}
