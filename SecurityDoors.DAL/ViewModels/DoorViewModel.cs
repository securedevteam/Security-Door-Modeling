using SecurityDoors.DAL.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SecurityDoors.DAL.ViewModels
{
    public class DoorViewModel : INotifyPropertyChanged
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
