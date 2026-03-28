using System;

namespace Task2
{
    class JsonException : Exception
    {
        public JsonException(string message) : base(message) { }
    }

    class JsonParser
    {
        public static string Parse(string json)
        {
            if (json.Length < 2 || json[0] != '{' || json[json.Length - 1] != '}')
                throw new JsonException("Некорректный JSON формат");
            return "OK";
        }
    }

    class ParsingException : Exception
    {
        public ParsingException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }

    class DataProcessor
    {
        public string ProcessData(string json)
        {
            try
            {
                return JsonParser.Parse(json);
            }
            catch (JsonException ex)
            {
                throw new ParsingException("Ошибка парсинга в DataProcessor", ex);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            DataProcessor proc = new DataProcessor();
            string[] tests = { "{}", "bad", "{test" };

            foreach (string json in tests)
            {
                try
                {
                    string result = proc.ProcessData(json);
                    Console.WriteLine("JSON: " + json + " -> " + result);
                }
                catch (ParsingException ex)
                {
                    Console.WriteLine("\nОБРАБОТКА ИСКЛЮЧЕНИЯ");
                    Console.WriteLine("Сообщение: " + ex.Message);
                    Console.WriteLine("Тип: " + ex.GetType().Name);
                    Console.WriteLine("Стек вызовов: " + ex.StackTrace);

                    Console.WriteLine("\nВНУТРЕННЕЕ ИСКЛЮЧЕНИЕ");
                    Console.WriteLine("Сообщение: " + ex.InnerException.Message);
                    Console.WriteLine("Тип: " + ex.InnerException.GetType().Name);
                }
            }
        }
    }
}