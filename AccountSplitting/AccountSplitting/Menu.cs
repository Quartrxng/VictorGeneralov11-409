using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Menu
    {
        public static void MenuCreate() { 
        bool flag = true;
            while (flag)
            {
                Console.WriteLine("=====Меню=====");
                Console.WriteLine("1 - Начать рассчет");
                Console.WriteLine("2 - Посмотреть историю");
                Console.WriteLine("3 - Настройки");
                Console.WriteLine("4 - Выйти"+"\n");
                var Menu = Console.ReadLine();

                switch (Menu)
                {
                    case "1":
                        Start.Starter();
                        break;
                    case "2":
                        FileWork.FileHistory();
                        Console.WriteLine(FileWork.HistoryString + "\n");
                        Console.WriteLine("Хотите открыть файл? + или -");
                        var answer = Console.ReadLine();
                        if (answer == "+")
                        {
                            Console.Write("Укажите номер файла: ");
                            FileWork.FilePrint(FileWork.HistoryList[int.Parse(Console.ReadLine())]);
                            Console.WriteLine(FileWork.FileString+ "\n");
                        }
                        break;
                    case "3":
                        
                        Console.WriteLine("\n" + "Папка сохранена в настройках." + "\n");
                        break;
                    case "4":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\n"+"Неверный выбор. Попробуйте снова." + "\n");
                        break;
                }
            }
        }
        public static void Separate()
        {
            Console.WriteLine("                         " + "\n" + "=========================" + "\n" + "                         ");
        }
    }
}
