using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSplit
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
                    (Name ?? "default_name") +
                    " " +
                    (Date ?? "default_date") +
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
            using (var file = new StreamWriter(directory, true))
            {
                file.Write(text + "\n");
            }
        }

        public static string[] FileRead(string FileDirectory)
        {
            var FileData = File.ReadAllLines(FileDirectory);
            return FileData;
        }
    }
}
