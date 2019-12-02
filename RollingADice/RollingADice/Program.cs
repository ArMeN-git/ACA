using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollingADice
{
    class Program
    {
        static void Main(string[] args)
        {
            Die dice = new Die();
            dice.TwoFours += GetEventsInformation;
            dice.SumOfRoles += GetEventsInformation;
            dice.Roll();
            Console.ReadKey();
        }

        static void GetEventsInformation(string msg)
        {
            ConsoleColor prev = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = prev;
        }
    }
}
