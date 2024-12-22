using System;
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
            var savedHistoryDirectory = ConfigManager.LoadConfig();
            if (string.IsNullOrWhiteSpace(savedHistoryDirectory) || !Directory.Exists(savedHistoryDirectory))
            {
                Console.WriteLine("Укажите папку для сохранения файлов:");
                savedHistoryDirectory = Console.ReadLine();

                ConfigManager.SaveConfig(savedHistoryDirectory);
                Console.WriteLine("Папка сохранена в настройках.");
            }
            else
            {
                Console.WriteLine($"Будет использоваться сохранённая папка: {savedHistoryDirectory}");
            }
            Menu.Separator();
        }
    }
}
