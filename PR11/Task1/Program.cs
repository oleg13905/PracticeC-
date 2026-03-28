using System;
using System.Collections.Generic;

namespace Task1
{

    public sealed class ConfigManager
    {
        private static ConfigManager instance;

        private static readonly object lockObject = new object();

        private Dictionary<string, string> config = new Dictionary<string, string>();

        private ConfigManager() { }

        public static ConfigManager Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ConfigManager();
                    }
                    return instance;
                }
            }
        }

        public void SetConfig(string key, string value)
        {
            config[key] = value;
            Console.WriteLine($"Установлена настройка: {key} = {value}");
        }

        public string GetConfig(string key)
        {
            if (config.TryGetValue(key, out string value))
            {
                return value;
            }
            Console.WriteLine($"Настройка {key} не найдена");
            return null;
        }

        public void PrintAll()
        {
            Console.WriteLine("\nВсе настройки:");
            foreach (var kvp in config)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            ConfigManager config1 = ConfigManager.Instance;
            config1.SetConfig("database", "localhost:5432");
            config1.SetConfig("debug", "true");
            config1.SetConfig("timeout", "30");

            ConfigManager config2 = ConfigManager.Instance;
            Console.WriteLine($"database: {config2.GetConfig("database")}");
            Console.WriteLine($"logLevel: {config2.GetConfig("logLevel")}");

            config2.SetConfig("theme", "dark");

            config1.PrintAll();
        }
    }
}