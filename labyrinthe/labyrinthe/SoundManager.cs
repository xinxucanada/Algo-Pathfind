using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using labyrinthe.Properties;

namespace labyrinthe
{
	internal class SoundManager
	{
		private static SoundPlayer startPlayer = new SoundPlayer();
		private static SoundPlayer blockPlayer = new SoundPlayer();
		private static SoundPlayer movePlayer = new SoundPlayer();

		public static void IniteSound()
		{
			startPlayer.Stream = Resources.start;
			blockPlayer.Stream = Resources.hit;
			movePlayer.Stream = Resources.fire;
		}
		public static void PlayStart()
		{
			startPlayer.Play();
		}
		public static void PlayBlock()
		{
			blockPlayer.Play();
		}
		public static void PlayMove()
		{
			movePlayer.Play();
		}
	}
}
