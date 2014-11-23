using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CSharp;

public struct Route
{
    public int X;
    public int Y;
    public int Time;
    public int Distance;

    public Route(int x, int y,int t, int d)
    {
        X = x; 
        Y = y;
        Time = t;
        Distance = d;
    }
}

static public class TravelMatrix
{
    //class to save the distanceMatrix in

    static Dictionary<Tuple<int, int>, Route> Routes = new Dictionary<Tuple<int, int>, Route>();

    static public void Init()
    {
        string path = "AfstandenMatrix.txt";

        using (System.IO.StreamReader str = new System.IO.StreamReader(path))
        {
            string line = str.ReadLine(); //first line is useless : headers of a file
            string[] words;

            while((line = str.ReadLine())!=null)
            {
                words = line.Split(';');
                addRoute(int.Parse(words[0]), int.Parse(words[1]), int.Parse(words[2]), int.Parse(words[3]));
            }
        }
        Console.WriteLine("Read in the Matrix");

    }
    private static void addRoute(int id1, int id2, int a, int t)
    {
        //save time and dist of this route
        Routes.Add(new Tuple<int,int>(id1,id2),new Route(id1,id2,t,a));
    }

    public static Route GetRoute(int loc1, int loc2)
    {
        return Routes[new Tuple<int, int>(loc1, loc2)];
    }
}
