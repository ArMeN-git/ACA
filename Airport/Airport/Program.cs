using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Airport> airset = new SortedSet<Airport>(new SortBySize())
            {
                new Airport("Some Name", "AM", "Small"),
                new Airport("Other Name", "RU", "SuperMega"),
                new Airport("Other Name2", "CA", "Large"),
                new Airport("Other Name3", "US", "Mega"),
                new Airport("Other Name4", "FR", "Medium"),
                new Airport("Other Name5", "CN", "Mediu")
            };
            foreach (var v in airset)
                Console.WriteLine(v);
            Console.ReadKey();
        }
    }
}
