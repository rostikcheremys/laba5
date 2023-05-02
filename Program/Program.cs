using System;

namespace Program
{
    struct MyTime 
    {
        public int hour, minute, second;
        public MyTime(int h, int m, int s)
        {
            hour = h;
            minute = m;
            second = s;
        }
        public override string ToString()
        {
            return $"{hour:D2}:{minute:D2}:{second:D2}";
        }
    }
    internal class Program
    {
        static int TimeSinceMidnight(MyTime t)
        {
            return t.hour * 3600 + t.minute * 60 + t.second;
        }
        static MyTime TimeSinceMidnight(int t)
        {
            int hour = t / 3600;
            t %= 3600;
            int minute = t / 60;
            int second = t % 60;
            
            return new MyTime(hour, minute, second);
        }
        static MyTime AddOneSecond(MyTime t) 
        {
            int totalSeconds = TimeSinceMidnight(t) + 1;
            
            return TimeSinceMidnight(totalSeconds);
        }
        static MyTime AddOneMinute(MyTime t) 
        {
            int totalSeconds = TimeSinceMidnight(t) + 60;
            
            return TimeSinceMidnight(totalSeconds);
        }
        static MyTime AddOneHour(MyTime t) 
        {
            int totalSeconds = TimeSinceMidnight(t) + 3600;
            
            return TimeSinceMidnight(totalSeconds);
        }
        static MyTime AddSeconds(MyTime t, int s) 
        {
            int totalSeconds = TimeSinceMidnight(t) + s;
            
            return TimeSinceMidnight(totalSeconds);
        }
        static int Difference(MyTime mt1, MyTime mt2) {
            int totalFirst = TimeSinceMidnight(mt1);
            int totalSecond = TimeSinceMidnight(mt2);
            int diff = Math.Abs(totalFirst - totalSecond);
            
            if (diff > 43200) diff = 86400 - diff;

            return diff;
        }
        public static void Main(string[] args)
        {
            Console.Write("Enter the time separated by spaces: ");

            string time = Console.ReadLine();
            string[] values = time.Split(' ');
            
            int hour = int.Parse(values[0]);
            int minute = int.Parse(values[1]);
            int second = int.Parse(values[2]);

            MyTime t = new MyTime(hour, minute, second);
            
            if (hour >= 0 && minute >= 0 && second >= 0 && hour <= 23 && minute <= 59 && second <= 59)
            {
                Console.WriteLine($"Time: {t.ToString()}"); 
                Console.WriteLine($"Seconds since midnight: {TimeSinceMidnight(t)}");
                Console.WriteLine($"Time from seconds: {TimeSinceMidnight(hour * 3600 + minute * 60 + second)}");
                Console.WriteLine($"Add one second: {AddOneSecond(t)}");
                Console.WriteLine($"Add one minute: {AddOneMinute(t)}");
                Console.WriteLine($"Add one hour: {AddOneHour(t)}");
                Console.WriteLine($"Add 10 seconds: {AddSeconds(t, 10)}");
                Console.WriteLine($"Difference between 12:00 and {t.ToString()} is {Difference(new MyTime(12, 0, 0), t)} seconds");
            }
            else
            {
                Console.WriteLine("Invalid time format!");
            }
        }
    }
}