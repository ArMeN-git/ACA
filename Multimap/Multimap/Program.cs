using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimap
{
    class Program
    {
        static void Main(string[] args)
        {
            Multimap<string, int> mt = new Multimap<string, int>();
            mt.Add("test", 25);
            mt.Add("test", 36);
            mt.Add("test", 47);
            mt.Add("some", 478);
            mt.Add("some", 167);
            mt.Add("other", 27);
            List<int> vals = mt["some"];
            foreach (var v in vals)
                Console.WriteLine(v);
            Console.WriteLine();
            foreach (var k in mt.Keys)
                Console.WriteLine(k);
            Console.WriteLine();
            Console.WriteLine(mt.Count);
            Console.WriteLine();
            Console.WriteLine(mt.ContainsKey("other"));
            Console.WriteLine();
            List<int> values;
            Console.WriteLine(mt.TryGetValue("test", out values));
            Console.WriteLine();
            foreach (var v in values)
                Console.WriteLine(v);
            Console.WriteLine();
            foreach (var list in mt.Values)
                foreach (var v in list)
                    Console.WriteLine(v);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}