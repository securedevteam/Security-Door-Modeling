namespace SecurityDoors.WPFApp.Models
{
    public class Message
	{
		public string PersonName { get; set; }
		public string PersonCard { get; set; }
		public int DoorId { get; set; }
		/// <summary>
		/// TODO: Нужно ли?
		/// </summary>
		public int DoorAccessLevel { get; set; }
	}
}
