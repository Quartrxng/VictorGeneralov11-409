using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSplit
{
    class Struct
    {
        public static string StructedString;

        public static StringBuilder UnStructedString = new StringBuilder();
        public static void Structuring(string text)
        {
            UnStructedString.AppendLine(text);
        }

        public static string Convert()
        {
            StructedString = UnStructedString.ToString() + Separator;
            UnStructedString.Clear();
            return StructedString;
        }

        public static string Separator = ("                         " + "\n" + "=========================" + "\n" + "                         ");
    }
}
