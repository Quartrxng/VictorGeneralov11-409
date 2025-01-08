using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSplitting
{
    internal class Validation
    {
        public static bool ValidationAnswer(string answer) 
        {
            if (answer == "+" || answer == "-")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool PositiveValidationDouble(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (double.TryParse(input,CultureInfo.InvariantCulture, out double result))
            {
                return result > 0;
            }
            return false;

        }
    }
}
