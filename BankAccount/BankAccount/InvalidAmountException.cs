using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class InvalidAmountException : Exception
    {
        public double Amount { get; }

        public InvalidAmountException() { }

        public InvalidAmountException(string message) : base(message) { }

        public InvalidAmountException(string message, double amount) : this(message)
        {
            this.Amount = amount;
        }
    }
}
