using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinthe
{
	// utile pour trier les labyrinthes (même JAVA code en projet continu)
	internal class TriFusion
	{
		private static Maze[] avatar;
		private static bool plusPetit(Maze e1, Maze e2)
		{
			return e1.minSteps - e2.minSteps <= 0; 
		}
		public static void sort(Maze[] arr)
		{
			avatar = new Maze[arr.Length];
			int debut = 0;
			int fin = arr.Length - 1;
			sort(arr, debut, fin);
			
		}

		public static void sort(Maze[] arr, int debut, int fin)
		{
			if (debut >= fin)
			{
				return;
			}
			int millieu = debut + (fin - debut) / 2;
			sort(arr, debut, millieu);
			sort(arr, millieu + 1, fin);
			merge(arr, debut, millieu, fin);
		}

		public static void merge(Maze[] arr, int debut, int millieu, int fin)
		{
			int pLeft = debut;
			int pRight = millieu + 1;
			int pAvatar = debut;

			while (pLeft <= millieu && pRight <= fin)
			{
				if (plusPetit(arr[pLeft], arr[pRight]))
				{
					avatar[pAvatar++] = arr[pLeft++];
				}
				else
				{
					avatar[pAvatar++] = arr[pRight++];
				}
			}
			while (pLeft <= millieu)
			{
				avatar[pAvatar++] = arr[pLeft++];
			}
			while (pRight <= fin)
			{
				avatar[pAvatar++] = arr[pRight++];
			}

			for (int i = debut; i <= fin; i++)
			{
				arr[i] = avatar[i];
			}
		}
	}
}
