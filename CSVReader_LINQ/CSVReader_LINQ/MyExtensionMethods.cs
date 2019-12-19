using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader_LINQ
{
    static class MyExtensionMethods
    {
        public static IEnumerable<Car> TopPowerFulCars(this IEnumerable<Car> cars)
        {
            var powerful = from car in cars
                           orderby car.Cylinders descending, car.CombinedFE descending
                           select car;

            return powerful.Take(20);
        }

        public static Car ToCar(this string line)
        {
            return new Car(line);
        }
    }
}
