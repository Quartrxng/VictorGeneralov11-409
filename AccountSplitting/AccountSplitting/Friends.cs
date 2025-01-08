using AccountSplitting;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp7
{
    internal class Friends
    {
        public static string FriendFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Friends.txt");
        public static string VeryRichestFriend { get; set; }
        public static Dictionary<string, string[]> FriendsDictionary = new Dictionary<string, string[]>();
        public static List<string> FriendsList = new List<string>();
        public static List<string[]> AllFriendListDebts = new List<string[]>();
        public static string FriendsString;

        public static void FriendCreate(string text)
        {
            FriendsList.AddRange(text.Split(',').Select(friend => friend.Trim()).Where(friend => !string.IsNullOrEmpty(friend)));

            if (!FriendsList.Contains(VeryRichestFriend))
                FriendsList.Add(VeryRichestFriend);

            if (!File.Exists(FriendFile))
                File.Create(FriendFile).Close();

            var friendArray = FileWork.FileRead(FriendFile);

            foreach (var friend in FriendsList)
            {
                if (!friendArray.Contains(friend))
                {
                    FileWork.FileWrite(FriendFile, friend);
                }
            }
        }
        public static void FriendsDebtSpecify(string text)
        {
            string[] FriendArray = text.Split('=');
            if (FriendArray.Length < 2 || FriendArray.Length > 2)
            {
                Console.WriteLine("Некорректный ввод");
                return;
            }
            try
            {
                FriendArray[0] = FriendArray[0].Trim();
                FriendArray[1] = FriendArray[1].Trim();
            }
            catch (Exception e)
            {
                Console.WriteLine("Неправильный ввод");
                return;
                
            }
            if (FriendArray[0] == VeryRichestFriend)
            {
                Console.WriteLine("Он не мог платить за себя");
                return;
            }
            
            double debtDouble;

            while (true)
            {
                if (Validation.PositiveValidationDouble(FriendArray[1]))
                {
                    debtDouble = double.Parse(FriendArray[1], CultureInfo.InvariantCulture);
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                    return;
                }
            }

            if (FileWork.FileRead(FriendFile).Contains(FriendArray[0]) && !FriendsDictionary.ContainsKey(FriendArray[0]) && FriendsList.Contains(FriendArray[0]))
            {
                FriendEdit(FriendArray[0], debtDouble);
            }
            else if (FileWork.FileRead(FriendFile).Contains(FriendArray[0]) && FriendsDictionary.ContainsKey(FriendArray[0]) && FriendsList.Contains(FriendArray[0]))
            {
                FriendEdit(FriendArray[0], double.Parse(FriendsDictionary[FriendArray[0]][0]) +debtDouble);
            }

            else if (!FileWork.FileRead(FriendFile).Contains(FriendArray[0]) && !FriendsDictionary.ContainsKey(FriendArray[0]) && !FriendsList.Contains(FriendArray[0]))
            {
                Console.WriteLine("Такого человека нету в списке друзей, хотите добавить его? + или -");
                while (true)
                {
                    var answer = Console.ReadLine();
                    if (Validation.ValidationAnswer(answer))
                    {
                        if (answer == "+")
                        {
                            FriendsList.Add(FriendArray[0]);
                            FriendEdit(FriendArray[0], debtDouble);
                            Console.WriteLine("Друг сохранен");

                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод");
                    }
                }
            }
            else if (FileWork.FileRead(FriendFile).Contains(FriendArray[0]) && !FriendsDictionary.ContainsKey(FriendArray[0]) && !FriendsList.Contains(FriendArray[0]))
            {
                Console.WriteLine("Такого человека нету в списке участников, хотите добавить его? + или -");
                while (true)
                {
                    var answer = Console.ReadLine();
                    if (Validation.ValidationAnswer(answer))
                    {
                        if (answer == "+")
                        {
                            FriendsList.Add(FriendArray[0]);
                            FriendEdit(FriendArray[0], debtDouble);
                            Console.WriteLine("Участник сохранен");

                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод");
                    }
                }
            }
        }
        public static void FriendInfo()
        {
            foreach (var friend in FriendsList)
            {
                if (!FriendsDictionary.ContainsKey(friend))
                {
                    FriendsDictionary[friend] = new string[] { "0.0", VeryRichestFriend };
                }
            }
        }

        public static void FriendEdit(string key, double debt)
        {
            if (!FriendsDictionary.ContainsKey(key))
            {
                FriendsDictionary[key] = new string[] { "0.0", VeryRichestFriend };
            }
            FriendsDictionary[key][0] = debt.ToString();
        }

        public static string FriendsListEdit()
        {
            var FriendsString = new StringBuilder();

            for (int i = 0; i < FriendsList.Count; i++)
            {
                if (FriendsDictionary.ContainsKey(FriendsList[i]) && FriendsDictionary[FriendsList[i]] != null)
                {
                    FriendsString.AppendLine($"{FriendsList[i]}: {FriendsDictionary[FriendsList[i]][0]}");
                }
                else
                {
                    FriendsString.AppendLine(FriendsList[i]);
                }
            }
            return FriendsString.ToString();
        }

        public static void ConcatLists()
        {
            foreach (var friend in FriendsDictionary) 
            {
                bool flag = true;
                for(var a = 0; a < AllFriendListDebts.Count; a++)
                {
                    if (AllFriendListDebts[a][0] == friend.Key && AllFriendListDebts[a][2] == friend.Value[1])
                    {
                        AllFriendListDebts[a][1] = (double.Parse(friend.Value[0]) + double.Parse(AllFriendListDebts[a][1])).ToString();
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    AllFriendListDebts.Add([friend.Key, friend.Value[0], friend.Value[1]]);
                }
            }
        }

        public static void Convert(string[] text)
        {
            var row = new StringBuilder();
            foreach (string frienddebt in text)
            {
                row.AppendLine(frienddebt);
            }
            FriendsString = row.ToString();
        }
    }
}