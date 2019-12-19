using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVReader_LINQ
{
    class FileReader
    {       
        public event EventHandler<FileReadCompletedEventArgs> FileReadCompleted;
        public event Action<int, string> ReadCompleted;
        public List<Car> ReadFile(string filePath)
        {
            List<Car> cars = new List<Car>();
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), "File path cannot be null or empty.");
            }
            int count = 0;
            try
            {
                using(StreamReader reader = new StreamReader(filePath))                
                {

                    string line = reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        count++;
                        line = reader.ReadLine();
                        cars.Add(new Car(line));
                    }
                }
                this.FileReadCompleted?.Invoke(this, new FileReadCompletedEventArgs(count));
                this.ReadCompleted(count, filePath.Split('.')[0]);
            }
            catch (FormatException ex)
            {
                throw new FileFormatExcpetion(++count, "Please check the file content.", ex);
                //throw new FormatException($"Please check the file content. Line number:{++count}");
            }
            catch (Exception)
            {
                throw;
            }
            return cars;
        }

        public List<Car> ReadCars(string path)
        {
            var query = from line in File.ReadAllLines(path).Skip(1)
                        where line.Length > 1
                        select new Car(line);

            var query1 = File.ReadAllLines(path)
                             .Skip(1)
                             .Where(l => l.Length > 1)
                             .Select(l => new Car(l));

            //TODO write extension method ToCar to convert each string to car object
            List<Car> cars = new List<Car>();
            foreach (string line in File.ReadAllLines(path))
                cars.Add(line.ToCar());

            return cars;

            //return query1.ToList();
        }

        public List<Manufacturer> ReadManufacturers(string path)
        {
            var query =
                   File.ReadAllLines(path)
                       .Where(l => l.Length > 1)
                       .Select(l =>
                       //TODO write equivalent Parse method in Manufacturer class with the following signature:
                       //static Manufacturer ParseToManufacturer(string line);
                       {
                           var columns = l.Split(',');
                           return new Manufacturer
                           {
                               Division = columns[0],
                               Headquarters = columns[1],
                               Year = int.Parse(columns[2])
                           };
                       });

            List<Manufacturer> mfs = new List<Manufacturer>();
            foreach (string line in File.ReadAllLines(path))
                mfs.Add(Manufacturer.ParseToManufacturer(line));

            return mfs;

            //return query.ToList();
        }
    }
}
