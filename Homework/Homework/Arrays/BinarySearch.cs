using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Homework.Arrays
{
    internal class BinarySearch
    {
        public static void Searcher()
        {
            int[] array = { 6, 2, 4, 5, 3, 1 };
            var find = false;

            int number = int.Parse(Console.ReadLine());
            var middelIndex = array.Length / 2;
            string result = "";

            while (find == false)
            {
                if (array[^1] > number || array[0] < number)
                {
                    Console.WriteLine("Число отсутствует в массиве");
                    break;
                }
                if (number < array[middelIndex])
                {
                    middelIndex /= 2;
                }
                else if (number > array[middelIndex]) middelIndex = middelIndex + middelIndex / 2;
                else
                {
                    find = true;
                    result = middelIndex.ToString();
                }
            }
            Console.WriteLine(result); // Индекс именно, чтобы получить индекс, счет которых начинается с 1, надо +1.
        }
    }
}
