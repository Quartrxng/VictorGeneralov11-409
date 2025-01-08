using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSplit
{
    internal class Calculator
    {
        public static StringBuilder ResultDebt = new StringBuilder();

        public static void DebtCalculate()
        {
            ResultDebt.Clear();

            foreach (var firstPayer in PartyDetailsPage.payers)
            {
                foreach (var secondPayer in PartyDetailsPage.payers)
                {
                    if (secondPayer.Value.ContainsKey(firstPayer.Key) && firstPayer.Value.ContainsKey(secondPayer.Key))
                    {
                        if (secondPayer.Value[firstPayer.Key] > firstPayer.Value[secondPayer.Key])
                        {
                            secondPayer.Value[firstPayer.Key] = secondPayer.Value[firstPayer.Key] - firstPayer.Value[secondPayer.Key];
                            firstPayer.Value.Remove(secondPayer.Key);
                        }
                        else if (secondPayer.Value[firstPayer.Key] == firstPayer.Value[secondPayer.Key])
                        {
                            firstPayer.Value.Remove(secondPayer.Key);
                            secondPayer.Value.Remove(firstPayer.Key);
                        }
                        else
                        {
                            firstPayer.Value[secondPayer.Key] = firstPayer.Value[secondPayer.Key] - secondPayer.Value[firstPayer.Key];
                            secondPayer.Value.Remove(firstPayer.Key);
                        }
                    }
                }
            }
            foreach (var payer in PartyDetailsPage.payers)
            {
                foreach (var debtor in payer.Value)
                {
                    if (debtor.Value!=0.0 || debtor.Value!=0)
                    {
                        ResultDebt.AppendLine($"{debtor.Key} должен {payer.Key}: {debtor.Value}");
                    }
                }
            }

        }

        public static string Result()
        {
            return ResultDebt.ToString();
        }
    }
}
