using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeProject
{
    public struct Time
    {
        public int MinutesSinceMidnight { get; private set; } 
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        private static readonly int HoursInDay = 24;
        public static readonly Time Noon = new Time(12, 0);

        public Time(int hour, int minute)
        {
            this.Hours = hour;
            this.Minutes = minute;
            this.MinutesSinceMidnight = (Hours * 60) + Minutes;
        }

        public static Time operator +(Time t1, int minutes)
        {
            int hour = t1.Hours + (minutes / 60) <= HoursInDay ? t1.Hours + (minutes / 60) : t1.Hours + (minutes / 60) - HoursInDay;
            int minute;
            if (t1.Minutes + (minutes % 60) >= 60)
            {
                hour = hour + 1 < HoursInDay ? hour + 1 : hour + 1 - HoursInDay;
                minute = t1.Minutes + (minutes % 60) - 60;
            }
            else
            {
                minute = t1.Minutes + (minutes % 60);
            }
            return new Time(hour, minute);
        }

        public static Time operator -(Time t1, int minutes)
        {
            int hour = t1.Hours - (minutes / 60) >= 0 ? t1.Hours - (minutes / 60) : HoursInDay + (t1.Hours - (minutes / 60));
            int minute;
            if(t1.Minutes - (minutes % 60) < 0)
            {
                hour = hour - 1 >= 0 ? hour - 1 : HoursInDay + hour - 1;
                minute = 60 + t1.Minutes - (minutes % 60);
            }
            else
            {
                minute = t1.Minutes - (minutes % 60);
            }
            return new Time(hour, minute);
        }

        public static implicit operator Time(int t)
        {
            int hour = t / 60 < HoursInDay ? t / 60 : t / 60 - HoursInDay;
            int minute = t % 60;
            return new Time(hour, minute);
        }

        public static explicit operator int(Time t)
        {
            return t.MinutesSinceMidnight;
        }

        public override string ToString()
        {
            string hour = this.Hours >= 10 ? this.Hours.ToString() : "0" + this.Hours.ToString();
            string minute = this.Minutes >= 10 ? this.Minutes.ToString() : "0" + this.Minutes.ToString();
            return $"{hour} : {minute}";
        }
    }
}
