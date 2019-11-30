using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Customer : Person
    {
        public int TotalMoney { get; private set; }

        public Customer(int id, string firstname, string lastname, int totalmoney) : base(id, firstname, lastname)
        {
            this.TotalMoney = totalmoney;
        }

        public override string ToString()
        {
            return $"ID: {this.ID}, Name: {this.FirstName} {this.LastName}, TotalMoney: {this.TotalMoney}";
        }
    }
}
