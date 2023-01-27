using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinthe
{
    internal class GameObjectManager
    {
        public static Maze maze;
        public static void Start()
        {
            maze = new Maze(StartMenu.rows, StartMenu.cols);
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
            maze.aStar();
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


	}
}
