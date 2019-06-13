using System.ComponentModel;
using System.Runtime.CompilerServices;

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
