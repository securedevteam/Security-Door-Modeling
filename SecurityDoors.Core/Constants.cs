namespace SecurityDoors.Core
{
    public static class Constants
    {
        public static readonly string STRING_EMPTY = string.Empty;

        public static readonly string SETTING_CORRECT = "Введенные настройки корректны.";
        public static readonly string SETTING_INCORRECT = "Введенные настройки некорректны.";
        public static readonly string SETTING_OPENING_WINDOW = "Открывается окно настроек.";
        public static readonly string SETTING_BINDING_FORM = "Устанавливается привязка к форме.";

        public static readonly string CONNECTION_ESTABLISHED = "Соединение установлено.";
        public static readonly string CONNECTION_NOT_ESTABLISHED = "Соединение не установлено.";

        public static readonly string CONVERSION_ERROR = "Ошибка при конвертации";
        public static readonly string DATA_API_FAILED = "Загрузка данных из API прошла неудачна.";
        public static readonly string DATA_API_SUCCESSED = "Загрузка данных из API прошла успешно.";
        public static readonly string DATA_API_DOWNLOADING_STARTED = "Начата загрузка данных из API.";
        public static readonly string DATA_SAVING_COMPLETED = "Сохранение данных в файл закончено.";
        public static readonly string DATA_SAVING_STARTED = "Начато сохранение данных в файл.";
        public static readonly string DATA_READING_ENDED = "Загрузка из файла закончена.";
        public static readonly string DATA_READING_STARTED = "Начата загрузка данных из файла.";

        public static readonly string DEFAULT_IP = "127.0.0.1";
        public static readonly string DEFAULT_PORT = "1234";
        public static readonly string DEFAULT_PORT_API = "80";
    }
}
