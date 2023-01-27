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

        public static void start()
        {
            //SoundManager.IniteSound();
            //GameObjectManager.Start();
            //GameObjectManager.CreateMap();
            //GameObjectManager.CreateMyTank();
            //SoundManager.PlayStart();
            GameObjectManager.Start();
        }

        public static void update()
        {
            //GameObjectManager.DrawMap();
            //GameObjectManager.DrawMyTank();
            if (gameState == GameState.Running)
            {
                GameObjectManager.Update();
            }
            //else if (gameState == GameState.Over)
            //{
            //    GameOverUpdate();
            //}
            //else if (gameState == GameState.Win)
            //{
            //    GameWinUpdate();
            //}
        }

        public static void GameOverUpdate()
        {
            //int x = 450 / 2 - Properties.Resources.GameOver.Width / 2;
            //int y = 450 / 2 - Properties.Resources.GameOver.Height / 2;
            //g.DrawImage(Properties.Resources.GameOver, x, y);
        }

        public static void GameWinUpdate()
        {
            //g.DrawString("You won !", new Font("Arial", 20), new SolidBrush(Color.Red), new Point(200, 200));
        }
        public static void GameOver()
        {
            gameState = GameState.Over;
        }

        public static void GameWin()
        {
            gameState = GameState.Win;
        }
    }
}
