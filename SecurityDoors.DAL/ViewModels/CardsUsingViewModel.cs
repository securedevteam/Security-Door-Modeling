using SecurityDoors.DAL.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SecurityDoors.DAL.ViewModels
{
    public class CardsUsingViewModel : INotifyPropertyChanged, IEnumerable
    {
        private List<Card> cards = new List<Card>();

        public List<Card> Cards
        {
            get
            {
                return cards;
            }
            set
            {
                cards = value;
                OnPropertyChanged(nameof(Cards));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

		public IEnumerator GetEnumerator()
		{
			return ((IEnumerable)Cards).GetEnumerator();
		}

		public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
