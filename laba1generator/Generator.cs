using System;
using System.Diagnostics;
namespace laba1generator
{
    class Generator
    {
        private static String basepath = @"D:\University\3course\5semester\SPP\labs\laba1\textfiles\";
        private static Stopwatch stopWatch = new Stopwatch();
        public static void LogTime(string message)
        {
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine(message + " " + elapsedTime);
        }
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Enter number of elements");
                long lines = Int64.Parse(Console.ReadLine());
                Console.WriteLine("Enter name of file to be created");
                String path = basepath+Console.ReadLine();

                LogTime("Starting generation");
                stopWatch.Start();
                laba1lib.Generator.Generate(lines, path);
                LogTime("Generation complete");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
