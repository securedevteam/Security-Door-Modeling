using System;

namespace SecurityDoors.DAL.Models
{
    /// <summary>
    /// Модель сотрудника.
    /// </summary>
    [Serializable]
    public class Person
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Уникальный номер карточки.
        /// </summary>
        public string CardUniqueNumber { get; set; }

        /// <summary>
        /// Ипспользована.
        /// </summary>
        public bool Use { get; set; }
    }
}
