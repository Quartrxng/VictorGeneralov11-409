using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ConsoleApp7
{
    internal class Calculator
    {
        public static StringBuilder ResultDebt = new StringBuilder();


        public static void DebtCalculate()
        {
            Calculator.ResultDebt.Append("Итог:\n");
            Dictionary<string, Dictionary<string,double>> payers = new Dictionary<string, Dictionary<string, double>>();
            Dictionary<string, double> debtors = new Dictionary<string, double>();
            foreach (var debtor in Friends.AllFriendListDebts)
            {
                if (!payers.ContainsKey(debtor[2]))
                {
                    payers[debtor[2]] = new Dictionary<string, double>();
                }
                payers[debtor[2]][debtor[0]] = double.Parse(debtor[1]);
            }

            foreach(var firstPayer in payers)
            {
                foreach(var secondPayer in payers)
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
            foreach(var payer in payers)
            {
                foreach (var debtor in payer.Value) 
                {
                    ResultDebt.AppendLine($"{debtor.Key} должен {payer.Key}: {debtor.Value}");
                }
            }

        }

        public static string Result()
        {
            return ResultDebt.ToString();
        }
    }
}