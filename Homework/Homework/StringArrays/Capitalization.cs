using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.StringArrays
{
    internal class Capitalization
    {
        public static void Capitalizator()
        {
            Console.WriteLine("Введите строку");
            string row = Console.ReadLine();
            string[] words = row.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string word = words[0][0].ToString().ToUpper() + words[0].ToString().Substring(1).ToLower();
            words[0] = word;
            for (int i = 1; i < words.Length; i++)
            {
                words[i] = words[i].ToString().ToLower();
            }
            Console.WriteLine(string.Join(" ", words));
        }
    }
}
