using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAttendance
{
    class Attendance
    {
        public event Action<string> CheckNameEvent;

        public void RegisterUser(string name)
        {
            if (name == "Steven" || name == "Mathew" || name == "Jack")
                CheckNameEvent?.Invoke("Please choose other username");
            else
                Console.WriteLine($"Welcome {name}");
        }
    }
}
