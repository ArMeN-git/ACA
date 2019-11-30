using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class SalesEmployee : Employee
    {
        List<Sale> sales;
        public SalesEmployee(int id, string firstname, string lastname, int salary, List<Sale> sales) : base(id, firstname, lastname, salary, Department.Sales)
        {
            this.sales = sales;
        }

        public override string ToString()
        {
            return base.ToString();
        }
        public void ShowSales()
        {
            Console.WriteLine("List of Sales");
            foreach (var s in sales)
                Console.WriteLine(s);
            Console.WriteLine();
        }
    }
    struct Sale
    {
        public string SaleName { get; set; }
        public DateTime date { get; private set; }
        public int Price { get; set; }

        public Sale(string salename, DateTime date, int price)
        {
            this.SaleName = salename;
            this.date = date;
            this.Price = price;
        }
        public override string ToString()
        {
            return $"SaleName: {this.SaleName}, Date: {this.date}, Price: {this.Price}";
        }
    }
}
