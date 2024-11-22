using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PrimitiveTypes
{
    internal class NestingDepth
    {
        public static void Meter()
        {
            Console.WriteLine("Количество значений в массиве?");
            var size = Int32.Parse(Console.ReadLine());
            string[] elements = new string[size];
            Console.WriteLine("Скобки, которые надо добавить в массив?");
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = Console.ReadLine();
            }
            int count = 0;
            int maxCount = -1000;
            foreach (string element in elements)
            {
                if (element == "(") count++;
                if (element == ")") count--;
                maxCount = Math.Max(maxCount, count);
            }
            if (count == 0) Console.WriteLine("true " + maxCount);
            else Console.WriteLine("false " + maxCount);
        }
    }
}
