namespace SecurityDoors.DAL.Models
{
    /// <summary>
    /// Модель карточки.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Уникальный номер.
        /// </summary>
        public string UniqueNumber { get; set; }

        /// <summary>
        /// Использована.
        /// </summary>
		public bool Use { get; set; } = false;
	}
}
