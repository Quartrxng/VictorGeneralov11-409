using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Menu
    {
        public static void MenuCreator() { 
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
                        FileWorker.FileHistory();
                        Console.WriteLine(FileWorker.HistoryString + "\n");
                        Console.WriteLine("Хотите открыть файл? + или -");
                        var answer = Console.ReadLine();
                        if (answer == "+")
                        {
                            Console.Write("Укажите номер файла: ");
                            FileWorker.FilePrinter(FileWorker.HistoryList[int.Parse(Console.ReadLine())]);
                            Console.WriteLine(FileWorker.FileString+ "\n");
                        }
                        break;
                    case "3":
                        Console.WriteLine("\n"+"Укажите папку для сохранения файлов:"+ "\n" );
                        var savedHistoryDirectory = Console.ReadLine();
                        ConfigManager.SaveConfig(savedHistoryDirectory);
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
        public static void Separator()
        {
            Console.WriteLine("                         " + "\n" + "=========================" + "\n" + "                         ");
        }
    }
}
