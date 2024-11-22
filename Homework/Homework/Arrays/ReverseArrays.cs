using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Arrays
{
    internal class ReverseArrays
    {
        public static void Reverser()
        {
            int[] array = { 6, 2, 4, 5, 3, 1 };
            int f, s;
            for (int i = 0; array.Length / 2 - 1 > i; i++)
            {
                s = array[^(i + 1)];
                f = array[i];
                array[i] = s;
                array[^(i + 1)] = f;
            }

            var str = string.Join(" ", array);
            Console.WriteLine(str);
        }
    }
}
