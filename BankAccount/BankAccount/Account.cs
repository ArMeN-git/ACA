using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Account
    {
        public double Balance { get; private set; }
        public static double InterestRate { get; private set; } = 10.0;

        public Account() { }

        public Account(double balance)
        {
            this.Balance = balance;
        }

        // Remove specified amount of money from the account
        public void WithDraw(double amount)
        {
            if (amount < 0)
                throw new InvalidAmountException("amount of money can't be negative", amount);
            else if (amount > this.Balance)
                throw new InvalidAmountException("amount of money can't be larger than the current balance", amount);
            else
                this.Balance -= amount;
        }

        // Add specified amount of money to the account
        public void Deposit(double amount)
        {
            if (amount < 0)
                throw new InvalidAmountException("amount of money can't be negative", amount);
            else
                this.Balance += amount;
        }

        // Set InterestRate value
        public static void SetInterestRate(double interestrate)
        {
            if (interestrate <= 0.0 || interestrate >= 22.0)
                throw new InvalidInterestRateException("InterestRate must be between 0.0 and 22.0", interestrate);
            else
                InterestRate = interestrate;
        }
    }
}
