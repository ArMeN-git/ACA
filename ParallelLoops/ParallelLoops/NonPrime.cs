using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelLoops
{
    class NonPrime
    {
        private List<int> numbers;

        public NonPrime(List<int> numbers)
        {
            this.numbers = numbers;
        }

        public List<int> DeleteNonPrimeElements()
        {
            List<int> result = new List<int>();
            bool isprime = true;
            Parallel.ForEach(numbers, n =>
            {
                Parallel.For(2, (int)Math.Sqrt(n) + 1, (int i, ParallelLoopState state) =>
                {
                    if (n % i == 0)
                    {
                        isprime = false;
                        state.Stop();
                    }
                });
                if (isprime)
                    result.Add(n);
                isprime = true;
            });
            return result;
        }
    }
}
