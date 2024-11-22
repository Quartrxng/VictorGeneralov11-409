using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PrimitiveTypes
{
    internal class LongestSubArray
    {
        public static void Finder()
        {
            Console.WriteLine("Количество значений в массиве?");
            var size = Int32.Parse(Console.ReadLine());
            int[] numbers = new int[size];
            Console.WriteLine("Числа, которые надо добавить в массив?");
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Int32.Parse(Console.ReadLine());
            }
            int startIndex = 0;
            int endIndex = 0;
            var length = 0;
            while (endIndex < numbers.Length)
            {
                if (numbers[startIndex] == numbers[endIndex])
                {
                    endIndex++;
                }
                else
                {
                    length = Math.Max(length, endIndex - startIndex);
                    startIndex = endIndex;
                }
                length = Math.Max(length, endIndex - startIndex);
            }
            Console.WriteLine(length);
        }
    }
}
