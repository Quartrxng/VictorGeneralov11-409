using AccountSplitting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Party
    {
        public static string Bar {get;set;}

        public static void AboutParty()
        {
            Console.WriteLine("Укажите название бара:");
            Bar = Console.ReadLine();
            Console.WriteLine("Укажите имя того, кто платил за тусовку?");
            Friends.VeryRichestFriend = Console.ReadLine();
            Struct.Structuring("=====Бар=====" + "\n" + Bar);
            Struct.Structuring("                          ");
            Struct.Structuring("=====Платил=====" + "\n" + Friends.VeryRichestFriend + "\n");
            PartyMembers();
            Console.WriteLine("Укажите счет каждого в формате Имя = сумма. Чтобы остановить напишите -");
            while (true)
            {
                var answer = Console.ReadLine();
                if (answer == "-") 
                { 
                    break;
                }
                Friends.FriendsDebtSpecify(answer);
            }
            Struct.Structuring(Friends.FriendsListEdit());
            FileWork.FileWrite(FileWork.FileFullName, Struct.Convert());
        }

        public static void PartyMembers()
        {
            if (Start.GlobalAnswer.Equals("-"))
            {
                Console.WriteLine("Укажите список всех друзей, кто был через запятую:");
                Struct.Structuring("=====Участники=====" + "\n");
                Friends.FriendCreate(Console.ReadLine() + "\n");
                while (true)
                {
                    Console.Write("Хотите добавить кого-то еще? + или -");
                    var answer = Console.ReadLine();
                    if (Validation.ValidationAnswer(answer))
                    {
                        if (answer.Equals("+"))
                        {
                            Console.WriteLine("Укажите список друзей, которых вы хотите добавить через запятую:");
                            Friends.FriendCreate(Console.ReadLine());
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод");
                        break;
                    }
                }
            }
            else
            {
                Struct.Structuring("=====Участники=====" + "\n");
            }
        }
    }
}
