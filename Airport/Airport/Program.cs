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
                new Airport("Some Name", "AM", Airport.Sizes.Small),
                new Airport("Other Name", "RU", Airport.Sizes.SuperMega),
                new Airport("Other Name2", "CA", Airport.Sizes.Large),
                new Airport("Other Name3", "US", Airport.Sizes.Mega),
                new Airport("Other Name4", "FR", Airport.Sizes.Medium),
            };
            foreach (var v in airset)
                Console.WriteLine(v);
            Console.ReadKey();
        }
    }
}
