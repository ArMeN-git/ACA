using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmApp
{
    class Alarm
    {
        public int Hour { get; }
        public int Minute { get; }

        public Alarm(int hour, int minute)
        {
            this.Hour = hour;
            this.Minute = minute;
        }

        public void Signal(object obj)
        {
            if (DateTime.Now.Hour == this.Hour && DateTime.Now.Minute == this.Minute)
            {
                Console.Write($"{this.Hour} : {this.Minute}  SIGNAL!!!");
                Console.WriteLine("  Press Escape key to switch off : ");
                Console.Beep();
                Console.Beep();
                Console.Beep();
            }
        }
    }
}
