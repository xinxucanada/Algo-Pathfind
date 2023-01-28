using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labyrinthe
{
    public partial class MapLabirinthe : Form
    {
        private Thread t;
        private static Graphics WindowG;
        private static Bitmap tempBmp;

        public MapLabirinthe()
        {
            InitializeComponent();

            //if (StartMenu.rows > 12 || StartMenu.cols > 12)
            //{
            //    BtnDFS.Enabled = false;
            //}
            Console.WriteLine(StartMenu.rows);
            Console.WriteLine(StartMenu.cols);
            WindowG = this.CreateGraphics(); // create graphic in gamewindow

            tempBmp = new Bitmap(1200, 1000); // create bitmap for game show
            
            Graphics bmpG = Graphics.FromImage(tempBmp); //create graphic from bitmap

            GameFramwork.g = bmpG;  // give empty graphic to gameframework for drawing

			t = new Thread(new ThreadStart(GameMainThread)); //create et start thread for game

            t.Start();


		}
        private static void GameMainThread()
        {
            //Game Framwork
            GameFramwork.start();

            int sleepTime = 1000 / 60;

            while (true)
            {
                GameFramwork.g.Clear(Color.Gray);  //背景涂黑
                GameFramwork.update(); //GameFramwork 的g发生改变
                WindowG.DrawImage(tempBmp, 0, 0); //GameFramwork 改变后的g, 改变了tempBmp, 然后tempBmp赋值给真正的windowG
				Thread.Sleep(sleepTime);
            }
        }

        

        private void MapLabirinthe_Load(object sender, EventArgs e)
        {

        }

        private void MapLabirinthe_FormClosed(object sender, FormClosedEventArgs e)
        {
            t.Abort();
        }

		private void LbClose_Click(object sender, EventArgs e)
		{
            Application.Exit();
		}

		private void BtnDFS_Click(object sender, EventArgs e)
		{
            GameObjectManager.PathDfs();
		}

		private void BtClear_Click(object sender, EventArgs e)
		{
			GameObjectManager.MapReset();
		}

		private void BtnRegenerate_Click(object sender, EventArgs e)
		{
			GameObjectManager.ReGenerer();
		}
        public void MinStepShow()
        {
            
        }

		private void LbStep_EnabledChanged(object sender, EventArgs e)
		{

		}

		private void BtBFS_Click(object sender, EventArgs e)
		{
			GameObjectManager.PathBfs();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			GameObjectManager.PathAStar();
		}

        private void BtRecursion_Click(object sender, EventArgs e)
        {
            GameObjectManager.PathDFSRapide();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            GameObjectManager.SaveMap();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            GameObjectManager.LoadMap();
        }
    }
}
