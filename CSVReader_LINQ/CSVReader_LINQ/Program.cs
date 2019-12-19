using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVReader_LINQ
{
    //TODO write extension method for cars collection to return the first 20 powerful cars (take into account EngDispl, Cylinders fields

    class Program
    {
        static void Main(string[] args)
        {
            AppDomain curr = AppDomain.CurrentDomain;
            curr.UnhandledException += OnUnhandledException;

            FileReader fileReader = new FileReader();
            string fileName = "../../cars.csv";

            fileReader.FileReadCompleted += OnFileReadCompleted;
            fileReader.ReadCompleted += FileReader_ReadCompleted;
            try
            {
                var cars = fileReader.ReadFile(fileName);
                List<Manufacturer> manufacturers = fileReader.ReadManufacturers("../../manufacturers.csv");

                var query = from car in cars
                            orderby car.CombinedFE descending, car.Carline ascending
                            select car;

                var query2 = cars.OrderByDescending(c => c.CombinedFE)
                                 .ThenBy(c => c.Carline);

                var query3 = from car in cars
                             where car.Division == "BMW"
                             orderby car.CombinedFE descending, car.Carline ascending
                             select car;

                var query4 = cars.Where(c => c.Division == "BMW")
                                 .OrderByDescending(c => c.CombinedFE)
                                 .ThenBy(c => c.Carline);

                var topCar = query4.FirstOrDefault();

                var topCarQuery = cars.OrderByDescending(c => c.CombinedFE)
                                      .ThenBy(c => c.Carline)
                                      .FirstOrDefault(c=>c.Division == "BMW");

                bool anyCar = cars.All(x => x.Division=="BMW");

                var query5 = cars.Where(c => c.Division == "BMW")
                                 .OrderByDescending(c => c.CombinedFE)
                                 .ThenBy(c => c.Carline)
                                 .Select(c => new { Year = c.ModelYear, c.Division, c.Carline});

                var query6 = from car in cars
                             group car by car.Division into carGroup
                             orderby carGroup.Count()
                             select carGroup;

                var query7 = cars.GroupBy(c => c.Division)
                                 .Select(c => new { Group = c, Count = c.Count()});

                var query8 = cars.GroupBy(c => c.Division).Count();

                var query9 = cars.OrderBy(c => c.CityFE)
                                 .GroupBy(c => c.Division)
                                 .OrderBy(c => c.Key)
                                 .ThenBy(c => c.Count());


                var query10 = cars.GroupBy(c => c.Division, c => new { c, c.Carline, c.CityFE })
                                .OrderBy(c => c.Key)
                                .ThenBy(c => c.Count());

                var query101 = cars.OrderBy(c => c.CityFE)
                                   .GroupBy(c => c.Division);

                //foreach (var item in query101)
                //{
                //    Console.WriteLine(item.Division, item.CityFE, item.Carline);
                //}

                var query11 = from car in cars
                              orderby car.CityFE
                              group car by car.Division into carGroup
                              select new
                              {
                                  carGroup,
                                  max = carGroup.Max(x=>x.CityFE)
                              };

                // TODO write the same query using extension menthods (in fluent syntax)
                var query12 = from car in cars
                              group car by car.Division into groups
                              select groups.OrderBy(c => c.CityFE).First();

                

                foreach (var v in query12)
                    Console.WriteLine(v.CityFE);

                Console.WriteLine();

                foreach (var v in query12_ext)
                    Console.WriteLine(v.CityFE);

                Console.WriteLine();

                var query15 = from car in cars
                              orderby car.CityFE
                              group car by car.Division into groups
                              orderby groups.Key
                              select groups.Last();

                //foreach (var car in query15)
                //{
                //    Console.WriteLine($"{car.Division} {car.Carline} {car.CityFE}");
                //}

                //TODO write a query to return min and max values for CityFE in each group of car divisions
                var minandmax = from car in cars
                                orderby car.CityFE
                                group car by car.Division into groups
                                select new
                                {
                                    cargroup = groups,
                                    min = groups.First().CityFE,
                                    max = groups.Last().CityFE
                                };

                foreach(var v in minandmax)
                {
                    Console.WriteLine(v.cargroup.Key);
                    Console.WriteLine($"Min CityFE: {v.min} , Max CityFE: {v.max} \n");
                }

                //join
                var query13 = from car in cars 
                              join mn in manufacturers on car.Division equals mn.Division
                              select new { car.Carline, car.Division, car.CityFE, mn.Headquarters, mn.Year };

                var query14 = cars.Join(manufacturers, 
                                        c => c.Division, 
                                        m => m.Division, 
                                        (c, m) => new { c.Carline, c.CityFE, c.Division, m.Headquarters});

                //TODO join cars and manufacturers on two fields: Division and Year
                

                /*
                foreach (var item in query14)
                {
                   Console.WriteLine($"{item.Division}, " +
                       $"{item.CityFE}, {item.Carline}, " +
                       $"{item.Headquarters}");
                }               

                foreach (var item in query11)
                {
                    Console.WriteLine($"{item.carGroup.Key} {item.max}");

                    Console.WriteLine($"\t{item.carGroup.Max(x=>x.CityFE)}");
                    //foreach (var car in item.carGroup)
                    //{

                    //    Console.WriteLine($"\t{car.Carline} {car.Division} {car.CityFE}");
                    //}
                }
                */

                //Console.WriteLine($"number of divisions: {query8}");

                //foreach (var group in query6)
                //{
                //    Console.WriteLine($"{group.Key} : count {group.Count()}");
                //    foreach (var item in group)
                //    {
                //        Console.WriteLine($"\t{item.Division} {item.Carline}");
                //    }
                //}

                //foreach (var group in query7)
                //{
                //    Console.WriteLine($"{group.Group.Key} : count {group.Count}");
                //    foreach (var item in group.Group)
                //    {
                //        Console.WriteLine($"\t{item.Division} {item.Carline}");
                //    }
                //}

                //foreach (var group in query9)
                //{
                //    Console.WriteLine($"{group.Key} : count {group.Count()}");
                //    foreach (var item in group)
                //    {
                //        Console.WriteLine($"\t{item.Division} {item.Carline} : {item.CityFE}");
                //    }
                //}

                /*
                if (topCar != null)
                {
                    Console.WriteLine($"\n{topCar.Division}, {topCar.Carline}\n");
                }

                foreach (var item in query4.Take(10))
                {
                   // Console.WriteLine($"{item.Carline}, {item.Division} : {item.CombinedFE}");
                }

                foreach (var item in query5)
                {
                   // Console.WriteLine($"{item.Carline}, {item.Year}, {item.Division}");
                }
                */

                var querypower = cars.TopPowerFulCars();
                foreach (var c in querypower)
                   Console.WriteLine($"{c.Carline}: {c.Cylinders}, {c.CombinedFE}");

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Cannot find specified file.\n {ex}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Please do not use the file while reading.\n {ex}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"{ex}");
            }
            catch (FormatException ex)
            {
                //Log.Error(ex);
                Console.WriteLine($"{ex.Message}");
            }
            catch (FileFormatExcpetion ex)
            {
                Console.WriteLine($"{ex.Message}\n {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong.\n {ex}");
            }

            Console.ReadKey();
        }

        #region private methods
        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine($"An error occurred. The application will be closed. \n {e.ExceptionObject}");
        }

        private static void FileReader_ReadCompleted(int arg, string name)
        {
            Console.WriteLine($"{arg}, {name}");
        }

        private static void OnFileReadCompleted(object sender, FileReadCompletedEventArgs args)
        {
              
            Console.WriteLine($"File read completed. Lines count: {args.Lines}");
        }
        #endregion
    }
}
