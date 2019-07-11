namespace SecurityDoors.Core
{
    public static class Constants
	{
		public static readonly string STRING_EMPTY = string.Empty;

		public static readonly string SETTING_CORRECT = "Введенные настройки корректны.";
        public static readonly string SETTING_INCORRECT = "Введенные настройки некорректны.";
        public static readonly string SETTING_OPENING_WINDOW = "Открывается окно настроек.";
        public static readonly string SETTING_BINDING_FORM = "Устанавливается привязка к форме.";
        public static readonly string SETTING_SAVE_SUCCESSED = "Операция выполнена успешно.";
        public static readonly string SETTING_SAVE_FAILED = "Операция выполнена с ошибкой.";
        public static readonly string SETTING_NULL = "Получен null или пустая строка.";

        public static readonly string CONNECTION_ESTABLISHED = "Соединение установлено.";
		public static readonly string CONNECTION_NOT_ESTABLISHED = "Соединение не установлено.";
		public static readonly string CONNECTION_API_FAILED = "Соединение с сервером API не установлено.";
		public static readonly string CONNECTION_API_SUCCESSED = "Соединение с сервером API установлено.";
		public static readonly string CONNECTION_DOOR_CONTROLLER_FAILED = "Соединение с сервером не установлено.";
		public static readonly string CONNECTION_DOOR_CONTROLLER_SUCCESSED = "Соединение с сервером установлено.";
		
        public static readonly string DATA_API_FAILED = "Загрузка данных из API прошла с ошибкой.";
        public static readonly string DATA_API_SUCCESSED = "Загрузка данных из API прошла успешно.";
        public static readonly string DATA_API_DOWNLOADING_STARTED = "Начата загрузка данных из API.";
        public static readonly string DATA_SAVING_COMPLETED = "Сохранение данных в файл завершено.";
        public static readonly string DATA_SAVING_STARTED = "Начато сохранение данных в файл.";
        public static readonly string DATA_READING_ENDED = "Загрузка из файла завершена.";
        public static readonly string DATA_READING_FAILED = "Загрузка из файла прошла с ошибкой.";
        public static readonly string DATA_READING_STARTED = "Начата загрузка данных из файла.";

        public static readonly string SENDING_MESSAGE_STARTED = "Передача данных в DoorController начата.";
        public static readonly string SENDING_MESSAGE_ENDED = "Перадача данных в DoorController успешно завершена.";
        public static readonly string SENDING_MESSAGE_FAILED = "Перадача данных в DoorController прошла с ошибкой.";

        public static readonly string CONVERSION_ERROR = "Ошибка при конвертации.";
        public static readonly string COMBOBOX_EMPTY = "Список дверей пуст.";

        public static readonly string ENTER_IP_ADDRESS = "Пожалуйста, введите IP адрес: "; // Please enter IP Address
        public static readonly string ENTER_PORT = "Пожалуйста, введите номер порта: "; // Please enter port number
        public static readonly string ENTER_API_PORT = "Пожалуйста, введите номер API порта: "; // Please enter port numbe
        public static readonly string ENTER_SECRET_KEY = "Пожалуйста, введите секретный ключ: "; // Please enter secret key
        public static readonly string ENTER_COUNT_MESSAGE_LIST = "Пожалуйста, введите количество сообщений в списке: "; // Please enter a count of the message list
        public static readonly string ENTER_NUMBER_TO_REPEAT = "Пожалуйста, введите количество раз, чтобы повторить операцию: "; // Please enter a number to repeat the operation
        public static readonly string ENTER_NUMBER_TO_DELAY = "Пожалуйста, введите количество секунд, чтобы отложить операцию: "; // Please enter a number to delay the operation
        public static readonly string ENTER_DOWNLOADING_BY_API = "Необходимо скачать данные из API (Y / N): "; // Need to download data from API (Y/N):

        public static readonly string SOFTWARE_OPERATION_FAILED = "Ошибка программного обеспечения.."; // Software operation failed..
        public static readonly string SOFTWARE_OPERATION_SUCCESSFULLY = "Успешное завершение программного обеспечения.."; // Software operation completed successfully..
        public static readonly string SOFTWARE_OPERATION_EXIT = "Команда не распознана! Выход из приложения.."; // Command unrecognized! Application exit

        public static readonly string DEFAULT_IP = "127.0.0.1";
        public static readonly int DEFAULT_PORT = 1234;
        public static readonly int DEFAULT_PORT_API = 80;
		public static readonly string DEFAULT_SECRET_KEY = "DEFAULT SECRET KEY";
	}
}
