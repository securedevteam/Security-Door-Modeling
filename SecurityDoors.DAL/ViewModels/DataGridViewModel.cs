using SecurityDoors.DAL.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SecurityDoors.DAL.ViewModels
{
    /// <summary>
    /// Класс ViewModel для отображения данных в таблице.
    /// </summary>
    public class DataGridViewModel: INotifyPropertyChanged
    {
        private List<Person> peopleAndCardsList;

        /// <summary>
        /// Список сотрудников.
        /// </summary>
        public List<Person> PeopleAndCardsList
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
            PeopleAndCardsList = new List<Person>();
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
