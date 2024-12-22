using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp7
{
    internal class Friends
    {
        public static string FriendFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Friends.txt");
        public static string VeryRichestFriend { get; set; }
        public static Dictionary<string, double> FriendsDictionary = new Dictionary<string, double>();
        public static string FriendsString;
        public static List<string> FriendsList = new List<string>();

        public static void FriendCreator(string text)
        {
            FriendsList.AddRange(text.Split(',').Select(friend => friend.Trim()).Where(friend => !string.IsNullOrEmpty(friend)));

            if (!FriendsList.Contains(VeryRichestFriend))
                FriendsList.Add(VeryRichestFriend);

            if (!File.Exists(FriendFile))
                File.Create(FriendFile).Close();

            var friendArray = FileWorker.FileReader(FriendFile);

            foreach (var friend in FriendsList)
            {
                if (!friendArray.Contains(friend))
                {
                    FileWorker.FileWriter(FriendFile, friend);
                }
            }
        }
        public static void FriendsDebt(string text)
        {
            string[] FriendArray = text.Split('=');
            FriendArray[0] = FriendArray[0].Trim();
            FriendArray[1] = FriendArray[1].Replace(".", ",").Trim();
            double debtDouble;

            while (true)
            {
                try
                {
                    debtDouble = double.Parse(FriendArray[1], NumberStyles.Float, CultureInfo.InvariantCulture);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Вы ввели не число, попробуйте снова.");
                }
            }

            if (FileWorker.FileReader(FriendFile).Contains(FriendArray[0]) && !FriendsDictionary.ContainsKey(FriendArray[0]))
            {
                FriendEditor(FriendArray[0], debtDouble);
            }
            else if(FileWorker.FileReader(FriendFile).Contains(FriendArray[0]) && FriendsDictionary.ContainsKey(FriendArray[0]))
            {
                FriendsList.Add(FriendArray[0]);
                FriendEditor(FriendArray[0], debtDouble);
            }

            else if (!FileWorker.FileReader(FriendFile).Contains(FriendArray[0]))
            {
                Console.WriteLine("Такого человека нету в списке друзей, хотите добавить его? + или -");
                var answer = Console.ReadLine();
                if (answer == "+")
                {
                    FriendCreator(FriendArray[0]);
                    FriendEditor(FriendArray[0], debtDouble);
                    Console.WriteLine("Друг сохранен");
                }
            }
        }

        public static void FriendEditor(string key, double debt)
        {
            FriendsDictionary[key] = debt;
        }

        public static string FriendsListEditor()
        {
            var FriendsString = new StringBuilder();

            for (int i = 0; i < FriendsList.Count; i++)
            {
                if (FriendsDictionary.ContainsKey(FriendsList[i]) && FriendsDictionary[FriendsList[i]] != null)
                {
                    FriendsString.AppendLine($"{FriendsList[i]}: {FriendsDictionary[FriendsList[i]]}");
                }
                else
                {
                    FriendsString.AppendLine(FriendsList[i]);
                }
            }
            return FriendsString.ToString();
        }
        public static void Converter(string[] text)
        {
            var row = new StringBuilder();
            foreach (string frienddebt in text)
            {
                row.AppendLine(frienddebt);
            }
            string FriendsString = row.ToString();
        }
    }
}