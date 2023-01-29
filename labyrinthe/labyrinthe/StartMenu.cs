using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labyrinthe
{
    public partial class StartMenu : Form
    {
        public static int rows = 1;
        public static int cols = 1;
        public StartMenu()
        {
            InitializeComponent();
        }

        private void BtStart_Click(object sender, EventArgs e)
        {
            try
            {
                rows = Convert.ToInt32(TbRows.Text);
                //rows = 5;
                cols = Convert.ToInt32(TbCols.Text);
                //cols = 5;
            }
            catch (Exception)
            {
                rows = 6;
                cols = 6;
            }
            new MapLabirinthe().Show();
            this.Hide();
        }

        private void RdFacile_CheckedChanged(object sender, EventArgs e)
        {
            new MapLabirinthe().Show();
            GameObjectManager.LoadMap();
            this.Hide();
        }
    }
}
