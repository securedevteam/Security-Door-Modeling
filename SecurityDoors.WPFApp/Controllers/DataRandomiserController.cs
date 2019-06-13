using SecurityDoors.WPFApp.Models;
using System;
using System.Collections.Generic;

namespace SecurityDoors.WPFApp.Controllers
{
    public class DataRandomiserController
	{
		public Random random;
		public List<Card> randomCards = new List<Card>();
		public List<Door> randomDoors = new List<Door>();
		public List<Person> randomPeople = new List<Person>();
		public void MakeRandomData ()
		{
            var cards = new Card[20];
            for (var i = 0; i < 20; i++)
            {
                 cards[i] =  new Card { UniqueNumber = Guid.NewGuid().ToString() };
            }
			randomCards.AddRange(cards);

			var doors = new Door[]
			{
				new Door { Name = "Главный вход"},
				new Door { Name = "Вход для охраны"},
				new Door { Name = "Пожарный выход №1"},
				new Door { Name = "Пожарный выход №2"},
				new Door { Name = "Пожарный выход №3"},
				new Door { Name = "Пожарный выход №4"},
				new Door { Name = "Дверь на крышу"},
				new Door { Name = "Дверь в подвал"},
				new Door { Name = "Подсобное помещение"},
				new Door { Name = "Рабочая зона №1"},
				new Door { Name = "Рабочая зона №2"},
				new Door { Name = "Зона для посетителей"},
				new Door { Name = "Дверь в правое крыло"}
			};
			randomDoors.AddRange(doors);

			var people = new Person[]
			{
				new Person { FirstName="Иван", SecondName = "Иванович", LastName = "Иванов", CardUniqueNumber = randomCards[0].UniqueNumber},
				new Person { FirstName="Петр", SecondName = "Петрович", LastName = "Петров", CardUniqueNumber = randomCards[1].UniqueNumber},
				new Person { FirstName="Михаил", SecondName = "Михайлович", LastName = "Михайлов", CardUniqueNumber = randomCards[2].UniqueNumber},
				new Person { FirstName="Алексей", SecondName = "Алексеевич", LastName = "Алсексеев", CardUniqueNumber = randomCards[3].UniqueNumber},
				new Person { FirstName="Юрий", SecondName = "Юрьевич", LastName = "Юрьев", CardUniqueNumber = randomCards[4].UniqueNumber},
				new Person { FirstName="Василиса", SecondName = "Васильевна", LastName = "Вась" , CardUniqueNumber = randomCards[5].UniqueNumber},
				new Person { FirstName="Иосиф", SecondName = "Виссарионович", LastName = "Сталин", CardUniqueNumber = randomCards[6].UniqueNumber},
				new Person { FirstName="Леонид", SecondName = "Леонидович", LastName = "Леонов", CardUniqueNumber = randomCards[7].UniqueNumber},
				new Person { FirstName="Родион", SecondName = "Родионович", LastName = "Родионов", CardUniqueNumber = randomCards[8].UniqueNumber},
				new Person { FirstName="Елена", SecondName = "Алексеевна", LastName = "Головач", CardUniqueNumber = randomCards[9].UniqueNumber},
				new Person { FirstName="Александра", SecondName = "Александровна", LastName = "Иванова", CardUniqueNumber = randomCards[10].UniqueNumber},
				new Person { FirstName="Николай", SecondName = "Николаевич", LastName = "Николаев", CardUniqueNumber = randomCards[11].UniqueNumber},
			};

			randomPeople.AddRange(people);
		}
	}
}
