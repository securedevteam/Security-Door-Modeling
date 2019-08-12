namespace SecurityDoors.DAL.Models
{
    /// <summary>
    /// Модель для TCP сообщения.
    /// </summary>
    public class TCPMessage
    {
        /// <summary>
        /// Карточка сотрудника.
        /// </summary>
        public string PersonCard { get; set; }

        /// <summary>
        /// Название двери.
        /// </summary>
        public string DoorName { get; set; }
    }
}
