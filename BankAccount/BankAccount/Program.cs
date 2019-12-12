using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            Account a1 = new Account(1000.0);
            try
            {
                Console.WriteLine(a1.Balance);
                a1.WithDraw(1100);
            }
            catch (InvalidAmountException e)
            {
                Console.WriteLine($"{e.Message}, invalid value: {e.Amount}");
            }
            try
            {
                Account.SetInterestRate(22.7);
            }
            catch (InvalidInterestRateException e)
            {
                Console.WriteLine($"{e.Message}, invalid value: {e.InterestRate}");
            }
            Console.ReadKey();
        }
    }
}
