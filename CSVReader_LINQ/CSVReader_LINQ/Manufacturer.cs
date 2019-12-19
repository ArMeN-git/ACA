using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader_LINQ
{
    class Manufacturer
    {
        public string Division { get; set; }
        public string Headquarters { get; set; }
        public int Year { get; set; }

        public static Manufacturer ParseToManufacturer(string line)
        {
            var columns = line.Split(',');
            return new Manufacturer { Division = columns[0], Headquarters = columns[1], Year = int.Parse(columns[2]) };
        }
    }
}
