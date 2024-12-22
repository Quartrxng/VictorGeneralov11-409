using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp7
{
    internal class FileWorker
    {
        public static string Date { get; set; }
        public static string Name { get; set; }

        public static StringBuilder FileText = new StringBuilder();

        public static String FileString;

        public static string HistoryString;

        public static List<string> HistoryList = new List<string>();

        


        ///public static string FileFullName = Path.Combine(ConfigManager.LoadConfig(), Name.Replace(' ', '_'), "_", Date, ".txt");

        public static string FileFullName
        {
            get
            {
                // Проверяем, что Name и Date не равны null
                return Path.Combine(
                    ConfigManager.LoadConfig(),
                    (Name ?? "default_name")+
                    " "+
                    (Date ?? "default_date")+
                    ".txt"
                );
            }
        }

        public static string FileCreator ()
        {
            var file = File.Create(FileFullName);
            file.Close();
            return FileFullName;
        }

        public static void FileWriter (string directory, string text)
        {
            var file = new StreamWriter(directory, true);
            file.Write(text + "\n");
            file.Close();
        }

        public static string[] FileReader(string FileDirectory)
        {
            var FileData = File.ReadAllLines(FileDirectory);
            return FileData;
        }

        public static void FilePrinter(string FileDirectory)
        {
            foreach(var line in FileReader(FileDirectory))
            {
                FileText.Append(line + "\n");
            }
            FileString = FileText.ToString();
            FileText.Clear();
        }

        public static void FileSeperateWriter() 
        {
            FileWriter(FileFullName, "                         ");
            FileWriter(FileFullName, "=========================");
            FileWriter(FileFullName, "                         ");
        }

        public static void FileHistory()
        {
            var allFiles = Directory.GetFiles(ConfigManager.LoadConfig(), "*.txt");
            var Files = new StringBuilder();
            Files.AppendLine("=====История=====" + "\n");
            var position = 0;
            foreach (var file in allFiles)
                {
                if (Path.GetFileName(file) != "config.txt" & !string.IsNullOrEmpty(file) & !string.IsNullOrWhiteSpace(file))
                    {
                        position++;
                        Files.AppendLine("Позиция: " + position.ToString() + " Название файла: " + Path.GetFileName(file) + "\n");
                        HistoryList.Add(file);
                    }
                }
            HistoryString = Files.ToString();
        }
    }
}
