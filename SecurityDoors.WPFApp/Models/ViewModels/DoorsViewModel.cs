using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoors.WPFApp.Models.ViewModels
{
	public class DoorsViewModel : INotifyPropertyChanged
	{
		private string doorName;

		public string DoorName
		{
			get => doorName;
			set
			{
				doorName = value;
				OnPropertyChanged("DoorName");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}
