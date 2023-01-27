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
        public static int rows;
        public static int cols;
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
                rows = 12;
                cols = 12;
            }
            new MapLabirinthe().Show();
            this.Hide();
        }
    }
}
