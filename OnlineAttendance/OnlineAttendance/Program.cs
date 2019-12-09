using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAttendance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your username: ");
            string s = Console.ReadLine();
            Attendance at = new Attendance();
            at.CheckNameEvent += OnCheckName;
            at.RegisterUser(s);
            Console.ReadKey();
        }

        private static void OnCheckName(string obj)
        {
            Console.WriteLine(obj);
        }
    }
}
