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

        public enum Sizes
        {
            Small,
            Medium,
            Large,
            Mega,
            SuperMega
        }
        public Sizes size;
        public Airport(string name, string countryCode, Sizes size)
        {
            this.Name = name;
            this.CountryCode = countryCode;
            this.size = size;
        }
        public override string ToString()
        {
            return $"{Name}, {CountryCode}, {size}";
        }
    }
}
