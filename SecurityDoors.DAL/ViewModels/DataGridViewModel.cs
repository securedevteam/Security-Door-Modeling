﻿using SecurityDoors.DAL.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SecurityDoors.DAL.ViewModels
{
    public class DataGridViewModel : INotifyPropertyChanged
    {
        private List<Person> peopleAndCardsList;

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
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}