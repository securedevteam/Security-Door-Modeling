using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoors.WPFApp.Models
{
	public class Message
	{
		public string PersonName { get; set; }
		public string PersonCard { get; set; }
		public int DoorId { get; set; }
		/// <summary>
		/// TODO: Нужно ли?
		/// </summary>
		public int DoorAccessLevel { get; set; }
	}
}
