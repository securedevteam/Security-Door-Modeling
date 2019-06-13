using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoors.WPFApp.Models.ViewModels
{
	public class PeopleAndCardsViewModel : INotifyPropertyChanged
	{
		private string name;
		private string cardNumber;

		public string Name
		{
			get => name;
			set
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}
		public string CardNumber
		{
			get => cardNumber;
			set
			{
				name = value;
				OnPropertyChanged("CardNumber");
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
