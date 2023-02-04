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
		public static int mapIndex;
		public Choisir()
		{
			InitializeComponent();
		}

		private void Choisir_Load(object sender, EventArgs e)
		{
			// Générer 10 labyrinthes
			GameObjectManager.MazeChoisir();
			Populate();
			
		}
		//lister 10 labyrinthes dans 10 boutons
		private void Populate()
		{
			btnLb0.Text = $"Labyrinthe nécessitant {GameObjectManager.mazes[0].minSteps} étape ";
			btnLb1.Text = $"Labyrinthe nécessitant {GameObjectManager.mazes[1].minSteps} étape ";
			btnLb2.Text = $"Labyrinthe nécessitant {GameObjectManager.mazes[2].minSteps} étape ";
			btnLb3.Text = $"Labyrinthe nécessitant {GameObjectManager.mazes[3].minSteps} étape ";
			btnLb4.Text = $"Labyrinthe nécessitant {GameObjectManager.mazes[4].minSteps} étape ";
			btnLb5.Text = $"Labyrinthe nécessitant {GameObjectManager.mazes[5].minSteps} étape ";
			btnLb6.Text = $"Labyrinthe nécessitant {GameObjectManager.mazes[6].minSteps} étape ";
			btnLb7.Text = $"Labyrinthe nécessitant {GameObjectManager.mazes[7].minSteps} étape ";
			btnLb8.Text = $"Labyrinthe nécessitant {GameObjectManager.mazes[8].minSteps} étape ";
			btnLb9.Text = $"Labyrinthe nécessitant {GameObjectManager.mazes[9].minSteps} étape ";
		}
		//montrer labyrinthe choisi
		private void btnLb0_Click(object sender, EventArgs e)
		{
			mapIndex = 0;
			new MapLabirinthe().Show();
		}
		private void btnLb1_Click(object sender, EventArgs e)
		{
			mapIndex = 1;
			new MapLabirinthe().Show();
		}

		private void btnLb2_Click(object sender, EventArgs e)
		{
			mapIndex = 2;
			new MapLabirinthe().Show();
		}

		private void btnLb3_Click(object sender, EventArgs e)
		{
			mapIndex = 3;
			new MapLabirinthe().Show();
		}

		private void btnLb4_Click(object sender, EventArgs e)
		{
			mapIndex = 4;
			new MapLabirinthe().Show();
		}

		private void btnLb5_Click(object sender, EventArgs e)
		{
			mapIndex = 5;
			new MapLabirinthe().Show();
		}

		private void btnLb6_Click(object sender, EventArgs e)
		{
			mapIndex = 6;
			new MapLabirinthe().Show();
		}

		private void btnLb7_Click(object sender, EventArgs e)
		{
			mapIndex = 7;
			new MapLabirinthe().Show();
		}

		private void btnLb8_Click(object sender, EventArgs e)
		{
			mapIndex = 8;
			new MapLabirinthe().Show();
		}

		private void btnLb9_Click(object sender, EventArgs e)
		{
			mapIndex = 9;
			new MapLabirinthe().Show();
		}

		private void btnRegenerate_Click(object sender, EventArgs e)
		{
			GameObjectManager.MazeChoisir();
			Populate();
		}

		private void btnTri_Click(object sender, EventArgs e)
		{
			GameObjectManager.TriMaps();
			Populate();
		}
	}
}
