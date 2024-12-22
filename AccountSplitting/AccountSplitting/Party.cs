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
            Struct.Structurer("=====Бар=====" + "\n" + Bar);
            Struct.Structurer(Struct.Separator);
            Struct.Structurer("=====Платил=====" + "\n" + Friends.VeryRichestFriend + "\n");
            PartyMembers();
            Console.WriteLine("Укажите счет каждого в формате Имя = сумма. Чтобы остановить напишите -");
            while (true)
            {
                var answer = Console.ReadLine();
                if (answer == "-") 
                { 
                    break;
                }
                Friends.FriendsDebt(answer);
            }

            Struct.Structurer(Friends.FriendsListEditor());
            FileWorker.FileWriter(FileWorker.FileFullName, Struct.Converter());
            Calculator.DebtCalculator();
        }

        public static void PartyMembers()
        {
            if (Start.GlobalAnswer.Equals("-"))
            {
                Console.WriteLine("Укажите список всех друзей, кто был через запятую:");
                Struct.Structurer("=====Участники=====" + "\n");
                Friends.FriendCreator(Console.ReadLine() + "\n");
                while (true)
                {
                    Console.WriteLine(Friends.FriendsString);
                    Console.Write("Хотите добавить кого-то еще? + или -");
                    var answer = Console.ReadLine();
                    if (answer.Equals("+"))
                    {
                        Console.WriteLine("Укажите список друзей, которых вы хотите добавить через запятую:");
                        Friends.FriendCreator(Console.ReadLine());
                    }
                    else 
                    { 
                        break; 
                    }
                }
            }
            else
            {
                Struct.Structurer("=====Участники=====" + "\n");
            }
        }
    }
}
