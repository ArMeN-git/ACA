using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ParallelLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 7, 2, 40, 8, 9, 37, 5, 52, 23, 21, 16, 1, 169, 411, 412 };
            foreach(int n in numbers)
                Console.Write(n + " ");
            Console.WriteLine();
            NonPrime np = new NonPrime(numbers);
            List<int> nums = np.DeleteNonPrimeElements();
            foreach(int n in nums)
                Console.Write(n + " ");
            Console.ReadKey();
        }
    }
}
