using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voxel_Prueba_Tecnica.Models
{
	public class Dice
	{
		public static int Roll()
		{
			var rand = new Random();
			return rand.Next(1,6);
		}
	}
}
