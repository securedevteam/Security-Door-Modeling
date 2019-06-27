using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoors.BL.Models.ViewModels
{
	public class DoorsViewModel : INotifyPropertyChanged
	{
		private List<Door> doors = new List<Door>();
		public List<Door> Doors
		{
			get
			{
				return doors;
			}
			set
			{
				doors = value;
				OnPropertyChanged(nameof(Doors));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
