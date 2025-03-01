﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class ConfigManager
    {
        public static string ConfigFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt");

        public static string LoadConfig()
        {
            if (File.Exists(ConfigFile))
            {
                return File.ReadAllText(ConfigFile).Trim();
            }
            return string.Empty;
        }

        public static void SaveConfig(string directory) 
        { 
            File.WriteAllText(ConfigFile, directory);
        }
        public static void Config()
        {
            var savedHistoryDirectory = LoadConfig();
            if (string.IsNullOrWhiteSpace(savedHistoryDirectory) || !Directory.Exists(savedHistoryDirectory))
            {
                while (true)
                {
                    Console.WriteLine("\n" + "Укажите папку для сохранения файлов (Чтобы использовать текущую папку напишите default):" + "\n");
                    savedHistoryDirectory = Console.ReadLine();
                    if (Directory.Exists(savedHistoryDirectory))
                    {
                        SaveConfig(savedHistoryDirectory);
                        Console.WriteLine("Папка сохранена в настройках" + "\n");
                        break;
                    }
                    else if (savedHistoryDirectory == "default")
                    {
                        SaveConfig(AppDomain.CurrentDomain.BaseDirectory);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Такой папки не существует");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Будет использоваться сохранённая папка: {savedHistoryDirectory}");
            }
            Menu.Separate();
        }
    }
}
