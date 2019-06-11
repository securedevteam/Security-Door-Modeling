namespace SecurityDoors.WPFApp.Models
{
    class Person
    {
        public string name { get; }
        public string card { get; }
        public Person(string name, string card)
        {
            this.name = name;
            this.card = card;
        }
    }
}