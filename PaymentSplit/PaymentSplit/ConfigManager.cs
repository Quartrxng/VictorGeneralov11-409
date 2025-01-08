using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSplit
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
            SaveConfig(AppDomain.CurrentDomain.BaseDirectory);
            return File.ReadAllText(ConfigFile).Trim();
        }

        public static void SaveConfig(string directory)
        {
            File.WriteAllText(ConfigFile, directory);
        }
    }
}
