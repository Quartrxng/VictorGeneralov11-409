using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Homework.Arrays
{
    internal class BubbleSort
    {
        public static void Sorter()
        {
            int[] array = { 6, 2, 4, 5, 3, 1 };
            int f, s;
            var switches = 0;
            do
            {
                switches = 0;
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        f = array[j];
                        s = array[j + 1];
                        array[j] = s;
                        array[(j + 1)] = f;
                        switches++;
                    }
                }
            }
            while (switches != 0);

            var str = string.Join(" ", array);
            Console.WriteLine(str);
        }
    }
}
