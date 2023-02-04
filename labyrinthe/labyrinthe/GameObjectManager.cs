using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labyrinthe
{
    internal class GameObjectManager
    {
        public static Maze maze;
        public static Maze[] mazes = new Maze[10];

        // creer 10 labyrinthes, calculer leur meilleur chemin
        public static void MazeChoisir()
        {
            Console.WriteLine("mazechoisir");
            Console.WriteLine(StartMenu.rows);

            for(int i = 0; i < mazes.Length; i++)
            {
               Console.WriteLine(i);
                mazes[i] = new Maze(StartMenu.rows, StartMenu.cols);
                mazes[i].aStar(0);
			}
        }
        public static void Start()
        {
            maze = mazes[Choisir.mapIndex];
            MapReset();

		}

        public static void Update()
        {
            maze.DrawSelf();
        }

        public static void PathDfs()
        {
            maze.dfs();
        }
		public static void PathBfs()
        {
            maze.bfs();
        }
		public static void PathAStar()
        {
            maze.aStar(1);
        }
        public static void PathDFSRapide()
        {
            maze.setWay();
        }
        public static void MapReset()
        {
            maze.setCarre();
            maze.CurrentSteps = 0;
            maze.nbrVisite = 1;
            maze.minSteps = Maze.N;
        }
        public static void ReGenerer()
        {
            maze.setWallH();
            maze.setWallV();
            maze.blockDigui();
            maze.setCarre();
            maze.minSteps = Maze.N;
			maze.CurrentSteps = 0;
			maze.nbrVisite = 1;
		}

        public static void SaveMap()
        {
            maze.SaveWall();
        }
        public static void LoadMap()
        {
            maze.LoadWall();
        }
        public static void Manuel()
        {
            maze.Manuel();
			SoundManager.PlayStart();
		}

        //test keyboard evenement
        public static void KeyDown(KeyEventArgs e)
        {
            maze.KeyDown(e);

		}


	}
}
