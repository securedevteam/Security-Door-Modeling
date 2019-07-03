namespace SecurityDoors.BLL.Interfaces
{
    interface IConnectionSettings
    {
        /// <summary>
        /// Сохранить настройки.
        /// </summary>
        /// <returns></returns>
        string SaveProperties();

        /// <summary>
        /// Установить стандартные настройки.
        /// </summary>
        void SetDefaultProperties();

        /// <summary>
        /// Проверить корректность данных.
        /// </summary>
        string CheckSettings();

        /// <summary>
        /// Проверить корректность данных.
        /// </summary>
        /// <param name="ip">IP адрес.</param>
        /// <param name="port">порт.</param>
        /// <param name="portApi">API порт.</param>
        /// <param name="secretKey">секретный ключ.</param>
        /// <returns>Результат проверки.</returns>
        string CheckSettings(string ip, int? port, int? portApi, string secretKey);
    }
}
