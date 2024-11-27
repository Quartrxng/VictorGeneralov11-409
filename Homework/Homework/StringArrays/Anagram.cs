using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.StringArrays
{
    internal class Anagram
    {
        public static void Qualifier()
        {
            Console.WriteLine("Введите два слова через пробел");
            var words = (Console.ReadLine().Split(" "));
            string word1 = words[0];
            string word2 = words[1];
            bool anagram = true;
            if (word1.Length == word2.Length)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (!word2.Contains(word1[i])) 
                    {
                        anagram = false;
                        break;
                    }
                }
            }
            else { anagram = false;}
            if (anagram) Console.WriteLine(word1 + " " + word2 + " - анаграмма");
            else Console.WriteLine(word1 + " " + word2 + " - не анаграмма");
        }
    }
}
