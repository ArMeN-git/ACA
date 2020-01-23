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
            if (hour >= 0 && hour <= 23)
                this.Hours = hour;
            else
                throw new ArgumentException("The hour should be in range [0;23]");
            if (minute >= 0 && minute <= 59)
                this.Minutes = minute;
            else
                throw new ArgumentException("The minute should be in range [0;59]");
            this.MinutesSinceMidnight = (Hours * 60) + Minutes;
        }

        // Adding minutes to given Time
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

        // Substracting minutes from given Time
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

        // Adding two Time values
        public static Time operator +(Time t1, Time t2)
        {
            int sumOfHours = t1.Hours + t2.Hours;
            int hour = sumOfHours < HoursInDay ? sumOfHours : sumOfHours - HoursInDay;
            int sumOfMinutes = t1.Minutes + t2.Minutes;
            int minute;
            if(sumOfMinutes >= 60)
            {
                hour = hour + 1 < HoursInDay ? hour + 1 : hour + 1 - HoursInDay;
                minute = sumOfMinutes - 60;
            }
            else
            {
                minute = sumOfMinutes;
            }
            return new Time(hour, minute);
        }

        // Substracting two Time values
        public static Time operator -(Time t1, Time t2)
        {
            int diffOfHours = t1.Hours - t2.Hours;
            int hour = diffOfHours >= 0 ? diffOfHours : HoursInDay + diffOfHours;
            int diffOfMinutes = t1.Minutes - t2.Minutes;
            int minute;
            if (diffOfMinutes < 0)
            {
                hour = hour - 1 >= 0 ? hour - 1 : HoursInDay + (hour - 1);
                minute = 60 + diffOfMinutes;
            }
            else
            {
                minute = diffOfMinutes;
            }
            return new Time(hour, minute);
        }

        // implicit cast from int to Time
        public static implicit operator Time(int t)
        {
            int hour = t / 60 < HoursInDay ? t / 60 : t / 60 - HoursInDay;
            int minute = t % 60;
            return new Time(hour, minute);
        }

        // explicit cast from Time to int
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
