using System;
using System.Globalization;
using System.Threading;
namespace ConsoleApp36
{
    struct MyTime
    {



        public MyTime(int h, int m, int s)
        {


            hour = h;
            minute = m;
            second = s;


        }
        public int hour, minute, second;
        public override string ToString()
        {
         
            return String.Format("{0:00}:{1:00}:{2:00}", Program.time.hour, Program.time.minute, Program.time.second);
        }
    };
    class Program
    {
        public static MyTime time;
        public static int sec;
        public static string lesson;

        private static int SinceMidnight()
        {
            sec = time.hour * 3600 + time.minute * 60 + time.second;
            return sec;
        }
        private static MyTime TimeSinceMidnight()
        {
            int secPerDay = 60 * 60 * 24;
            int mysec;
            mysec = ((sec % secPerDay) + secPerDay) % secPerDay;
            int h = mysec / 3600;
            int m = (mysec / 60) % 60;
            int s = mysec % 60;
            return time;
        }
        private static MyTime AddOneSecond()
        {
            if (time.second == 59)
            {
                time.minute++;
                time.second = 0;
            }
            return time;
        }
        private static MyTime AddOneMinute()
        {
            if (time.minute == 60)
            {
                time.hour++;
                time.minute = 0;
            }
            return time;
        }
        private static MyTime AddOneHour()
        {
            if (time.hour == 24)
            {
                time.hour = 0;
                time.minute = 0;
            }
            return time;
        }
        private static int AddSeconds()
        {
            AddOneSecond();
            AddOneMinute();
            AddOneHour();
            return time.second++;
        }

        static string WhatLesson()
        {
            int slesson1= 28800;
            int slesson2=35400;
            int slesson3=41400;
            int slesson4=46800;
            int slesson5 = 52800;
            int slesson6=58200;
            int ends = 63000;
            int sbreakten=600;
           int sbreaktwenty=1200;
            if (sec < slesson1)
            {
                lesson = "пари ще не почалися";

            }
            else if (sec >= slesson1 && sec < slesson2-sbreakten)
            {
                lesson = "1 пара";

            }
            else if (sec >= slesson2 - sbreakten && sec < slesson2)
            {
                lesson = "перерва між 1 та 2 парою";

            }
            else if (sec >= slesson2 && sec < slesson3-sbreaktwenty)
            {
                lesson = "2 пара";

            }
            else if (sec >= slesson3 - sbreaktwenty && sec < slesson3)
            {
                lesson = "перерва між 2 та 3 парою";

            }
            else if (sec >= slesson3 && sec < slesson4-sbreakten)
            {
                lesson = "3 пара";

            }
            else if (sec >= slesson4 - sbreakten && sec < slesson4)
            {
                lesson = "перерва між 3 та 4 парою";

            }
            else if (sec >= slesson4 && sec < slesson5-sbreaktwenty)
            {
                lesson = "4 пара";

            }
            else if (sec >= slesson5 - sbreaktwenty && sec < slesson5)
            {
                lesson = "перерва між 4 та 5 парою";

            }
            else if (sec >= slesson5 && sec <slesson6-sbreakten)
            {
                lesson = "5 пара";

            }
            else if (sec >= slesson6 - sbreakten && sec < slesson6)
            {
                lesson = "перерва між 5 та 6 парою";

            }
            else if (sec >= slesson6 && sec < ends)
            {
                lesson = "6 пара";

            }
            else if (sec >= ends)
            {
                lesson = "пари закінчилися";

            }


            return lesson;
        }


        static void Main()
        {

            Console.WriteLine("Введіть години");
            time.hour = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть хвилини");
            time.minute = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть секунди");
            time.second = int.Parse(Console.ReadLine());
            while (sec < 60 * 60 * 24)
            {

                Thread.Sleep(20);

                AddSeconds();

                SinceMidnight();
                TimeSinceMidnight();
                Console.Clear();
                Console.WriteLine(time.ToString());
                Console.WriteLine("sec " + sec);
                Console.WriteLine(WhatLesson());

            }
            Console.WriteLine("день закінчився");
        }
    }
}
