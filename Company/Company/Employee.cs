using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Employee : Person
    {
        public int Salary { get; private set; }
        public enum Department
        {
            Production,
            Accounting,
            Sales,
            Marketing
        }
        protected Department category;

        public Employee(int id, string firstname, string lastname, int salary, Department category) : base(id, firstname, lastname)
        {
            this.Salary = salary;
            this.category = category;
        }

        public override string ToString()
        {
            return $"ID: {this.ID}, Name: {this.FirstName} {this.LastName}, Salary: {this.Salary}, Category: {this.category}";
        }
    }
}
