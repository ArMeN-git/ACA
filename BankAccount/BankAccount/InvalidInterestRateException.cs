using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class InvalidInterestRateException : Exception
    {
        public double InterestRate { get; }

        public InvalidInterestRateException() { }

        public InvalidInterestRateException(string message) : base(message) { }

        public InvalidInterestRateException(string message, double interestrate) : this(message)
        {
            this.InterestRate = interestrate;
        }
    }
}
