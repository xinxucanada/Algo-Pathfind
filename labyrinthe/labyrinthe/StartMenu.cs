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
                cols = Convert.ToInt32(TbCols.Text);
            }
            catch (Exception)
            {
                //si entrée invalide, on prend 30 lignes et 30 colonnes par defaut
                rows = 20;
                cols = 20;
            }
            //créer fenêtre pour choisir labyrinthe
            new Choisir().Show();
            this.Hide();
        }

        // ancien code pour charger labyrinthe du fichier
        private void RdFacile_CheckedChanged(object sender, EventArgs e)
        {
            new MapLabirinthe().Show();
            GameObjectManager.LoadMap();
            this.Hide();
        }
    }
}
