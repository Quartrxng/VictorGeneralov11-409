using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.StringArrays
{
    internal class Palindrome
    {
        public static void Qualifier()
        {
            Console.WriteLine("Введите строку");
            string text = Console.ReadLine();
            string row = text.Replace(" ", "").Replace("-", "").Replace(",", "").Replace(":", "").Replace(".", "").Replace("?", "").Replace("!", "").Replace(";", "").Replace("'", "");
            bool palindrome = true;
            for (int i = 0; i < row.Length / 2; i++) 
            { 
                if ((row[i]).ToString().ToLower() != row[^(i+1)].ToString().ToLower())
                {
                    palindrome = false;
                }
            }
            if (palindrome) Console.WriteLine($"{text} - палиндром");
            else Console.WriteLine($"{text} - не палиндром");
        }
    }
}
