﻿using System;
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
            bool flag = true;
            while (flag)
            {
                Party.AboutParty();
                Console.Write("Хотите внести еще один бар? + или -");
                var answer = Console.ReadLine();
                if (answer == "-")
                {
                    flag = false;
                }
                else
                {
                    FileWorker.FileSeperateWriter();
                    Menu.Separator();
                    Calculator.ResultTotalDebt = 0;
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
            Struct.Structurer(Calculator.ResultDebt.ToString());
            FileWorker.FileWriter(FileWorker.FileFullName, Struct.Converter());
            FileWorker.FilePrinter(FileWorker.FileFullName);
            Menu.Separator();
            Console.WriteLine(FileWorker.FileString);
        }
        public static void FileCreate()
        {
            Console.WriteLine("Укажите название тусовки:");
            FileWorker.Name = Console.ReadLine();
            Console.WriteLine("               ");
            Console.WriteLine("Укажите дату:");
            FileWorker.Date = Console.ReadLine();
            FileWorker.FileCreator();
            Struct.Structurer("=====Тусовка=====" + "\n" + FileWorker.Name + "\n");
            Struct.Structurer("=====Дата=====" + "\n" + FileWorker.Date);
            FileWorker.FileWriter(FileWorker.FileFullName, Struct.Converter());
            Menu.Separator();
        }
    }
}
