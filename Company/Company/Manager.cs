using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Manager : Employee
    {
        List<Employee> employees;
        public Manager(int id, string firstname, string lastname, int salary, List<Employee> employees) : base(id, firstname, lastname, salary, Department.Marketing)
        {
            this.employees = employees;
        }

        public override string ToString()
        {
            return base.ToString();
        }
        public void ShowEmployeeList()
        {
            Console.WriteLine("List of Employees");
            foreach (var e in employees)
                Console.WriteLine(e);
            Console.WriteLine();
        }
    }
}
