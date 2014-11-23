using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Gansewinkel
{
    static void Main(string[] args)
    {
        System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();

        timer.Reset();
        timer.Start();

        //read AfstandenMatrix.txt
        TravelMatrix.Init();
        timer.Stop();
        Console.WriteLine("At " + timer.Elapsed.Hours + "h " + timer.Elapsed.Minutes + "m "+timer.Elapsed.Seconds+"."+timer.Elapsed.Milliseconds+"s ");

        //read Oders.txt
        timer.Reset();
        timer.Start();
        AllOrderss.Init();
        timer.Stop();
        Console.WriteLine("At " + timer.Elapsed.Hours + "h " + timer.Elapsed.Minutes + "m " + timer.Elapsed.Seconds + "." + timer.Elapsed.Milliseconds + "s ");

        return;
    }
}
