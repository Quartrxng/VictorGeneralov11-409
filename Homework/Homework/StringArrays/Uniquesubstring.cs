using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Homework.StringArrays
{
    internal class Uniquesubstring
    {
        public static void finder() 
        {
            Console.WriteLine("Введите строку");
            var text = Console.ReadLine();
            var longestSubstring = "";
            string substring = "" + text[0];

            for (var i = 1; i < text.Length; i++) 
            {
                
                if (!substring.Contains(text[i]))
                {
                    substring = substring + text[i];
                    if (longestSubstring.Length < substring.Length)
                    {
                        longestSubstring = substring;
                    }
                }
                else 
                {
                    while (substring.Contains(text[i]))
                    {
                        substring = substring.Substring(1);
                    }
                    substring = substring + text[i];
                }
            }
            Console.WriteLine(substring);
        }
    }
}
