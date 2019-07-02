using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SecurityDoors.DAL.ViewModels
{
    public class PeopleAndCardsViewModel : INotifyPropertyChanged
    {
        private string name;
        private string cardNumber;
        private bool use = false;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string CardNumber
        {
            get => cardNumber;
            set
            {
                cardNumber = value;
                OnPropertyChanged(nameof(CardNumber));
            }
        }

        public bool Use
        {
            get => use;
            set
            {
                use = value;
                OnPropertyChanged(nameof(Use));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
