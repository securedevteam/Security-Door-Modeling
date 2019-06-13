using System.ComponentModel;
using System.Runtime.CompilerServices;

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
