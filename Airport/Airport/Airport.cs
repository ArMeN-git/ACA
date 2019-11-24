using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Airport
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string Size { get; set; }
        public int NumOfSize { get; private set; }
        public Airport(string name, string countryCode, string size)
        {
            this.Name = name;
            this.CountryCode = countryCode;
            this.Size = size;
            if (size == "Small")
                this.NumOfSize = 0;
            else if (size == "Medium")
                this.NumOfSize = 1;
            else if (size == "Large")
                this.NumOfSize = 2;
            else if (size == "Mega")
                this.NumOfSize = 3;
            else if (size == "SuperMega")
                this.NumOfSize = 4;
            else
                Console.WriteLine("Invalid Size");
        }
        public override string ToString()
        {
            return $"{Name}, {CountryCode}, {Size}";
        }
    }
}
