﻿using AccountSplitting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Start
    {
        public static string GlobalAnswer = "-";
        public static void Starter()
        {
            ConfigManager.Config();
            FileCreate();
            while (true)
            {
                Party.AboutParty();
                Console.Write("Хотите внести еще один бар? + или -");
                Friends.ConcatLists();
                var answer = Console.ReadLine();
                if (Validation.ValidationAnswer(answer))
                {
                    if (answer == "-")
                    {
                        break;
                    }
                    else
                    {
                        FileWork.FileSeperateWrite();
                        Menu.Separate();
                        Console.Write("Хотите оставить тот же состав участников? + или -");
                        answer = Console.ReadLine();
                        if (answer == "-")
                        {
                            Friends.FriendsList.Clear();
                            Friends.FriendsDictionary.Clear();
                            GlobalAnswer = "-";
                        }
                        else
                        {
                            Friends.FriendsDictionary.Clear();
                            GlobalAnswer = "+";
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            Calculator.DebtCalculate();
            string result = Calculator.Result();
            Struct.Structuring(result);
            FileWork.FileWrite(FileWork.FileFullName, Struct.Convert());
            FileWork.FilePrint(FileWork.FileFullName);
            Menu.Separate();
            Console.WriteLine(FileWork.FileString);
        }
        public static void FileCreate()
        {
            Console.WriteLine("Укажите название тусовки:");
            FileWork.Name = Console.ReadLine();
            Console.WriteLine("               ");
            Console.WriteLine("Укажите дату:");
            FileWork.Date = Console.ReadLine();
            FileWork.FileCreate();
            Struct.Structuring("=====Тусовка=====" + "\n" + FileWork.Name + "\n");
            Struct.Structuring("=====Дата=====" + "\n" + FileWork.Date);
            FileWork.FileWrite(FileWork.FileFullName, Struct.Convert());
            Menu.Separate();
        }
    }
}
