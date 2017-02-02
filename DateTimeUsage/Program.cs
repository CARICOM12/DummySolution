using System;

namespace DateTimeUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 part
            DateTime currentDate = new DateTime();
            Console.WriteLine("Day of week: {0}", currentDate.DayOfWeek);

            //2 part
            DateTime dt = new DateTime();
            int daysInMonth = DateTime.DaysInMonth(dt.Year, dt.Month);
            Console.WriteLine("End of month became after {0}", daysInMonth - dt.Day);

            //3 part

            Console.ReadKey();
        }
    }
}
