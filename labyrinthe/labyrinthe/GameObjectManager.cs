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

            for(int i = 0; i < mazes.Length; i++)
            {
                mazes[i] = new Maze(StartMenu.rows, StartMenu.cols);
			}
            CalculerSteps();

		}
        // calculer le chemin le plus court
        public static void CalculerSteps()
        {
			for (int i = 0; i < mazes.Length; i++)
			{
				maze = mazes[i];
                MapReset();
                maze.aStar(0);
			}
		}

        public static void Start()
        {
            maze = mazes[Choisir.mapIndex];
            MapReset();

		}
		// Le tri des labyrinthes par son chemin le plus court, complexité temporaire O(nlgn)
		public static void TriMaps()
        {
			CalculerSteps();
			TriFusion.sort(mazes);
        }

        public static void Update()
        {
            maze.DrawSelf();
        }

        public static void PathDfs()
        {
			MapReset();
			maze.dfs();
        }
		public static void PathBfs()
        {
			MapReset();
			maze.bfs();
        }
		public static void PathAStar()
        {
			MapReset();
			maze.aStar(1);
        }
        public static void PathDFSRapide()
        {
			MapReset();
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
