using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(160127, "Armen", "Grigoryan");
            Console.WriteLine(p);
            Customer c = new Customer(178963, "Anun", "Azganun", 100000);
            Console.WriteLine(c);
            Employee e = new Employee(123456, "FirstName", "LastName", 350000, Employee.Department.Accounting);
            Console.WriteLine(e);
            Developer d = new Developer(111000, "FirstName1", "LastName1", 750000, new List<Project>{
                    new Project("Project1", DateTime.Now, "Some Details 111", Project.ProjectState.open),
                    new Project("Project2", DateTime.Now, "Some Details 222", Project.ProjectState.closed),
                    new Project("Project3", DateTime.Now, "Some Details 333", Project.ProjectState.open),
                });
            SalesEmployee s = new SalesEmployee(121203, "FirstName2", "LastName2", 350000, new List<Sale>{
                    new Sale("Some Sale", DateTime.Now, 15000),
                    new Sale("Some Sale2", DateTime.Now, 17000),
                    new Sale("Some Sale3", DateTime.Now, 25000)
                });
            List<Employee> emp = new List<Employee> { d, s };
            Manager m = new Manager(036985, "FirstName3", "LastName3", 300000, emp);
            Console.WriteLine(m);
            m.ShowEmployeeList();
            Console.WriteLine(d);
            d.SHowProjects();
            Console.WriteLine(s);
            s.ShowSales();
            Console.ReadKey();
        }
    }
}
