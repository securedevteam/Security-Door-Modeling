using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SecurityDoors.DAL.ViewModels
{
    /// <summary>
    /// Класс ViewModel для использования карточек и сотрудников.
    /// </summary>
    public class PeopleAndCardsViewModel: INotifyPropertyChanged
    {
        private string name;
        private string cardNumber;
        private bool use = false;

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Номер карточки.
        /// </summary>
        public string CardNumber
        {
            get => cardNumber;
            set
            {
                cardNumber = value;
                OnPropertyChanged(nameof(CardNumber));
            }
        }

        /// <summary>
        /// Использование.
        /// </summary>
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

        /// <summary>
        /// Вызывает событие изменения свойства.
        /// </summary>
        /// <param name="prop">Имя вызывающего метода.</param>
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
