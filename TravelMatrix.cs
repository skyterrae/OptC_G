using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public struct Route
{
    //simple tuple struct
    // waar zat de point classe ook weer?
    public int X;
    public int Y;

    public Route(int x, int y)
    {
        X = x; 
        Y = y;
    }
}

static public class TravelMatrix
{
    //class to save the distanceMatrix in

    static Dictionary<Route, int> Afstanden = new Dictionary<Route, int>();
    static Dictionary<Route, int> Tijden = new Dictionary<Route, int>();

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
        Route r = new Route(id1,id2);
        Afstanden.Add(r, a);
        Tijden.Add(r, t);
    }
    public static int GetTime(int loc1, int loc2)
    {
        //gets the traveling time between two locations
        Route r = new Route(loc1, loc2);
        return Tijden[r];

    }
    public static int GetDistance(int loc1, int loc2)
    {
        //gets the traveling time between two locations
        Route r = new Route(loc1, loc2);
        return Tijden[r];
   }
}
