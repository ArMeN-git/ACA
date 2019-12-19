using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLINQExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int> { 2, 6, 9, 23, 49, 75, 66, 2, 0 };
            var query1 = nums.MyWhere(n => n > 10 && n % 2 != 0);
            foreach (var n in query1)
                Console.Write(n + " ");
            Console.WriteLine();

            var query2 = nums.MySelect(n => n + 2);
            foreach (var n in query2)
                Console.Write(n + " ");
            Console.WriteLine();

            int[] numbers = new int[] { 4, 5, 9, 8, 11, 13, 17, 26 };
            var List_numbers = numbers.MyToList();
            List_numbers.Remove(13);
            foreach (var n in List_numbers)
                Console.Write(n + " ");
            Console.WriteLine();

            var dict = numbers.MyToDictionary(n => n, n => n % 2 != 0);
            foreach (var d in dict)
                Console.WriteLine($"key: {d.Key}, value: {d.Value}");

            Console.ReadKey();
        }
    }
}
