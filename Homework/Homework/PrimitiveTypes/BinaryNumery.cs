using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PrimitiveTypes
{
    internal class BinaryNumery
    {
        public static void Translator()
        {
            var x = Int32.Parse(Console.ReadLine());
            string result = "";
            while (x > 0)
            {
                result = (x % 2).ToString() + result;
                x = x / 2;
            }
            Console.WriteLine(result);
        }
    }
}
