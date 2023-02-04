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
	public partial class Choisir : Form
	{
		public Choisir()
		{
			InitializeComponent();
		}

		private void Choisir_Load(object sender, EventArgs e)
		{
			btnLb1.Text = $"Labyrinthe nécessitant 200 étape ";
		}
	}
}
