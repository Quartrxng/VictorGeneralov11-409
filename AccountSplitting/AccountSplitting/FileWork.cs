using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp7
{
    internal class FileWork
    {
        public static string Date { get; set; }
        public static string Name { get; set; }

        public static StringBuilder FileText = new StringBuilder();

        public static String FileString;

        public static string HistoryString;

        public static List<string> HistoryList = new List<string>();

        public static string FileFullName
        {
            get
            {
                return Path.Combine(
                    ConfigManager.LoadConfig(),
                    (Name ?? "default_name")+
                    " "+
                    (Date ?? "default_date")+
                    ".txt"
                );
            }
        }

        public static string FileCreate()
        {
            var file = File.Create(FileFullName);
            file.Close();
            return FileFullName;
        }

        public static void FileWrite(string directory, string text)
        {
            var file = new StreamWriter(directory, true);
            file.Write(text + "\n");
            file.Close();
        }

        public static string[] FileRead(string FileDirectory)
        {
            var FileData = File.ReadAllLines(FileDirectory);
            return FileData;
        }

        public static void FilePrint(string FileDirectory)
        {
            foreach(var line in FileRead(FileDirectory))
            {
                FileText.Append(line + "\n");
            }
            FileString = FileText.ToString();
            FileText.Clear();
        }

        public static void FileSeperateWrite() 
        {
            FileWrite(FileFullName, "                         ");
            FileWrite(FileFullName, "=========================");
            FileWrite(FileFullName, "                         ");
        }

        public static string FileHistory()
        {
            if (File.Exists(ConfigManager.ConfigFile))
            {
                var allFiles = Directory.GetFiles(ConfigManager.LoadConfig(), "*.txt");
                var Files = new StringBuilder();
                Files.AppendLine("=====История=====" + "\n");
                var position = 0;
                foreach (var file in allFiles)
                {
                    if (Path.GetFileName(file) != "config.txt" & Path.GetFileName(file) != "Friends.txt" & !string.IsNullOrEmpty(file) & !string.IsNullOrWhiteSpace(file))
                    {
                        position++;
                        Files.AppendLine("Позиция: " + position.ToString() + " Название файла: " + Path.GetFileName(file) + "\n");
                        HistoryList.Add(file);
                    }
                }
                return Files.ToString();
            }
            else
            {
                return "Истории нету";
            }
        }
    }
}
