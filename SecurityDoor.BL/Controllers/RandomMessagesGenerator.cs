using SecurityDoors.BL.Controllers;
using SecurityDoors.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoor.BL.Controllers
{
	//TODO: Удалить после приведения MainWindow в порядок
	public class RandomMessagesGenerator
	{
		private List<Message> Messages = new List<Message>();

		/// <summary>
		/// !ТРЕБУЕТ ПРИ КАЖДОМ ЗАПУСКЕ УКАЗЫВАТЬ НОВЫЙ СЕКРЕТНЫЙ КЛЮЧ!
		/// Генерирует случайные проходы дверей, после чего отправляет их на сервер. 
		/// </summary>
		public void MakeRandomMesages ()
		{
			var messageController = new MessageController();
			var dataRandomiser = new DataRandomiserController();
			dataRandomiser.MakeRandomData();

			//
			var secretKey = "ab6fc77d-a990-4342-ba8b-80f35df8b6b1";
			//

			foreach (var person in dataRandomiser.randomPeople)
			{
				Messages.Add(new Message() { SecretKey = secretKey, PersonCard = person.CardUniqueNumber, DoorName = dataRandomiser.randomDoors[new Random().Next(0,12)].Name });
			}

			messageController.SendMessages(Messages);
		}
	}
}
