using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Calculator
    {
        public static StringBuilder ResultDebt = new StringBuilder();
        public static double ResultTotalDebt;
        public static void DebtCalculate() 
        {
            ResultDebt.Append("=====Бар====="+ "\n" + Party.Bar + "\n" + "\n");
            foreach (var debtFriend in Friends.FriendsDictionary)
            {
                if (debtFriend.Value != 0)
                {
                    ResultDebt.Append(debtFriend.Key + " должен " + debtFriend.Value.ToString() + " => " + Friends.VeryRichestFriend + "\n");
                    ResultTotalDebt += debtFriend.Value;
                }
            }
            ResultDebt.Append('\n');
            ResultDebt.Append("Итог: " + ResultTotalDebt.ToString() + "\n" + "\n");
        }
    }
}
