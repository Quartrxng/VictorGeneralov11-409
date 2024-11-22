using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PrimitiveTypes
{
    internal class NumberOfNumbers
    {
        public static void Counter()
            {
            for (int i = 1; i < 28; i++)
            {
                int count = 0;
                for (int a = 1; a < 10; a++)
                {
                    for (int b = 0; b < 10; b++)
                    {
                        for (int c = 0; c < 10; c++)
                        {
                            if (a + b + c == i) count += 1;
                        }
                    }
                }
                Console.WriteLine(i + " " + count);
            }
        }
    }
}
