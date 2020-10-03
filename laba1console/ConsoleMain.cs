using System;
using laba1lib;
using System.Collections.Generic;
using System.Diagnostics;
class WriteTextFile
{
    private static String basepath = @"D:\University\3course\5semester\SPP\labs\laba1\textfiles\";
    private static Stopwatch stopWatch = new Stopwatch();
    public static void LogTime(string message)
    {
        TimeSpan ts = stopWatch.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        Console.WriteLine(message + " " + elapsedTime);
    }
    static void Main()
    {
        try { 
            Console.WriteLine("Enter name of file to be sorted");
            String path = basepath+Console.ReadLine();

            stopWatch.Start();
            LogTime("Starting splitting and sorting");
            List<String> filenames = Sorter.SplitAndSort(path,basepath);

            LogTime("Merge started");
            Sorter.MergeSortedFiles(filenames,path+"1");


            LogTime("File merge completed");
            Console.ReadLine();
            }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}