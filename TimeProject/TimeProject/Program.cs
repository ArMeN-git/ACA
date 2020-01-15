using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(14, 5);
            Time t2 = new Time(0, 20);

            Time t3 = t1 + 670;
            Console.WriteLine(t3.Hours);
            Console.WriteLine(t3.Minutes);
            Console.WriteLine(t3.MinutesSinceMidnight);
            Console.WriteLine();

            Time t4 = t2 - 25;
            Console.WriteLine(t4.Hours);
            Console.WriteLine(t4.Minutes);
            Console.WriteLine(t4.MinutesSinceMidnight);
            Console.WriteLine();

            Time t5 = 1850;
            Console.WriteLine(t5.Hours);
            Console.WriteLine(t5.Minutes);
            Console.WriteLine(t5.MinutesSinceMidnight);
            Console.WriteLine();

            int t6 = (int)new Time(21, 45);
            Console.WriteLine(t6);

            Console.WriteLine(Time.Noon);

            Console.WriteLine();
            Console.WriteLine(t1);
            Console.WriteLine(t2);
            Console.WriteLine(t3);
            Console.WriteLine(t4);
            Console.WriteLine(t5);
            Console.ReadKey();
        }
    }
}
