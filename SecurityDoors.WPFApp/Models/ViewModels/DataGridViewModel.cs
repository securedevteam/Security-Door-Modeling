using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SecurityDoors.WPFApp.Models.ViewModels
{
    public class DataGridViewModel : INotifyPropertyChanged
    {
		private ObservableCollection<PeopleAndCardsViewModel> peopleAndCardsList;

		public ObservableCollection<PeopleAndCardsViewModel> PeopleAndCardsList
		{
			get
			{
				return peopleAndCardsList;
			}
			set
			{
				peopleAndCardsList = value;
				OnPropertyChanged(nameof(PeopleAndCardsList));
			}
		}
		public DataGridViewModel()
		{
			PeopleAndCardsList = new ObservableCollection<PeopleAndCardsViewModel>();
		}

		public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
