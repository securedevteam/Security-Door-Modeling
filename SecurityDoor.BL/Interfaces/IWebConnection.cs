using SecurityDoors.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoor.BL.Interfaces
{
	public interface IWebConnection
	{
		/// <summary>
		/// TODO: Удалить после рефакторинга
		/// </summary>
		int Port { get; set; }
		int PortAPI { get; set; }
		string Server { get; set; }
		string SecretKey { get; set; }

		Task<bool> CheckServerConnectionAsync();
		Task<string> SendMessageAsync(string message);
		Task<string> SendMessageAsync(List<Person> people, string door);
		Task<List<Person>> GetPeopleFromAPIAsync();
		Task<List<Door>> GetDoorsFromAPIAsync();
	}
}
