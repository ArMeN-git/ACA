using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(3, 4);
            Console.WriteLine(c1);
            Complex c2 = new Complex(6, 7);
            Console.WriteLine(c2);
            Complex c3 = c1 + c2;
            Console.WriteLine(c3);
            c3 = c1 - c2;
            Console.WriteLine(c3);
            c3 = c1 * c2;
            Console.WriteLine(c3);
            c3 = c1 / c2;
            Console.WriteLine(c3);
            Console.WriteLine(c1.AbsoluteValue());
            Console.WriteLine(c1.Argument());
            Console.ReadKey();
        }
    }
}
