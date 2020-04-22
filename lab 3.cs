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



            if (sec < 28800)
            {
                lesson = "пари ще не почалися";

            }
            else if (sec >= 28800 && sec < 34800)
            {
                lesson = "1 пара";

            }
            else if (sec >= 34800 && sec < 35400)
            {
                lesson = "перерва між 1 та 2 парою";

            }
            else if (sec >= 35400 && sec < 40200)
            {
                lesson = "2 пара";

            }
            else if (sec >= 40200 && sec < 41400)
            {
                lesson = "перерва між 2 та 3 парою";

            }
            else if (sec >= 41400 && sec < 46200)
            {
                lesson = "3 пара";

            }
            else if (sec >= 46200 && sec < 46800)
            {
                lesson = "перерва між 3 та 4 парою";

            }
            else if (sec >= 46800 && sec < 51600)
            {
                lesson = "4 пара";

            }
            else if (sec >= 51600 && sec < 52800)
            {
                lesson = "перерва між 4 та 5 парою";

            }
            else if (sec >= 52800 && sec < 57600)
            {
                lesson = "5 пара";

            }
            else if (sec >= 57600 && sec < 58200)
            {
                lesson = "перерва між 5 та 6 парою";

            }
            else if (sec >= 58200 && sec < 63000)
            {
                lesson = "6 пара";

            }
            else if (sec >= 63000)
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
