using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoors.WPFApp.Models.ViewModels
{
	public class DoorsViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<string> doors = new ObservableCollection<string>();
		public ObservableCollection<string> Doors
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
