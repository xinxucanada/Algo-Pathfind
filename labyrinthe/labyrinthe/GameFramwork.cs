using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinthe
{
    enum GameState
    {
        Running,
        Over,
        Win
    }
    internal class GameFramwork
    {
        public static Graphics g;
        public static GameState gameState = GameState.Running;

        //initializer game objets
        public static void start()
        {
            GameObjectManager.Start();
			SoundManager.IniteSound();
		}

        // game objets mise-à-jour
        public static void update()
        {
            if (gameState == GameState.Running)
            {
                GameObjectManager.Update();
            }
        }
    }
}
