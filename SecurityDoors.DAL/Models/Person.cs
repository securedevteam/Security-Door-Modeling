using System;

namespace SecurityDoors.DAL.Models
{
    [Serializable]
    public class Person
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string CardUniqueNumber { get; set; }
        public bool Use { get; set; }
    }
}
