using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlarmApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the time for the alarm clock");
            Console.Write("Hours : ");
            int hours = int.Parse(Console.ReadLine());
            Console.Write("Minutes : ");
            int minutes = int.Parse(Console.ReadLine());
            Alarm a1 = new Alarm(hours, minutes);
            Timer t = new Timer(a1.Signal, null, 0, 1000);
            if(Console.ReadKey().Key == ConsoleKey.Escape)
                Console.WriteLine("Canceled");
        }
    }
}
