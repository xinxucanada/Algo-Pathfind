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
        private static int Frequence = 60;

        public MapLabirinthe()
        {
            InitializeComponent();
		
            WindowG = this.CreateGraphics(); // créer graphic sur gamewindow

            tempBmp = new Bitmap(1200, 1000); //créer bitmap pour game show

			Graphics bmpG = Graphics.FromImage(tempBmp); //créer graphic de bitmap

			GameFramwork.g = bmpG;  // donne graphic vide à gameframework pour y peindre

			t = new Thread(new ThreadStart(GameMainThread)); //créer et démarrer thread pour game

            t.Start();


		}
        private static void GameMainThread()
        {
            GameFramwork.start();
			//rafraîchissements par seconde
			int sleepTime = 1000 / Frequence;

            while (true)
            {
                GameFramwork.g.Clear(Color.Gray);  //donner background grey
                GameFramwork.update(); //graphis de GramFramwork update
                WindowG.DrawImage(tempBmp, 0, 0); //après GameFramwork change graphic, tempBmp change, puis donne tempBMP à GameWindow Graphic
				Thread.Sleep(sleepTime);
            }
        }

        

        private void MapLabirinthe_Load(object sender, EventArgs e)
        {
			KeyPreview = true;
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

		private void BtnManuel_Click(object sender, EventArgs e)
		{
			GameObjectManager.Manuel();
		}

	

		private void MapLabirinthe_KeyDown(object sender, KeyEventArgs e)
		{
			Console.WriteLine(e.KeyCode.ToString());
		}

		private void MapLabirinthe_KeyUp(object sender, KeyEventArgs e)
		{
			Console.WriteLine(e.KeyCode.ToString());
			GameObjectManager.KeyDown(e);
		}

		private void BtBack_Click(object sender, EventArgs e)
		{
            this.Close();
		}
	}
}
