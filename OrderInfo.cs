
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum Frequence{F_1,F_2,F_3,F_4,F_5};

public static class AllOrderss
{
    static public Dictionary<int,Order> Orders {get; private set;}

    static public void Init()
    {
        Orders = new Dictionary<int,Order>();

        string path = "Orderbestand.txt";

        using (System.IO.StreamReader str = new System.IO.StreamReader(path))
        {
            string line = str.ReadLine(); //first line is useless : headers of a file
            string[] words;

            while((line = str.ReadLine())!=null)
            {
                words = line.Split(';');
                addOrder(int.Parse(words[0]), words[1], words[2], int.Parse(words[3]),
                    int.Parse(words[4]), float.Parse(words[5]),int.Parse(words[6]),int.Parse(words[7]),int.Parse(words[8]));
            }
        }
        Console.WriteLine("Read in all the Orders");
    }
    private static void addOrder(int o, string l,string freq, int cAm, 
        int cVol,float leegM,int mID, int x, int y)
    {
        Frequence f = Frequence.F_5;
        switch(freq) 
        {
            case "1PW": f = Frequence.F_1; break;
            case "2PW": f = Frequence.F_2; break;
            case "3PW": f = Frequence.F_3; break;
            case "4PW": f = Frequence.F_4; break;
        }
        Order Or = new Order(o,l,f,cAm,cVol,leegM,mID,x,y);

        //key = matrixID
        Orders.Add(o, Or);
    }
    static public Order GetOrder(int key)
    {
        // key = MatrixID
        return Orders[key];
    }
}

public class Order
{
    public int OrderNr { get; private set; }
    public int ContainerAm { get; private set; }
    public int ContainerVol { get; private set; }
    public int MatrixID { get; private set; }
    public int XCoor { get; private set; }
    public int YCoor { get; private set; }
    public string Loc { get; private set; }
    public Frequence Freq { get; private set; }
    public float LeegMinutes { get; private set; }

    public Order(int order, string loc,Frequence freq, int containerAm, 
        int containerVol,float leegMinutes,int matrixID, int xCoor, int yCoor)
    {
        OrderNr = order;
        Loc = loc;
        Freq = freq;
        ContainerAm = containerAm;
        ContainerVol = containerVol;
        LeegMinutes = leegMinutes;
        MatrixID = matrixID;
        XCoor = xCoor;
        YCoor = yCoor;
    }
}
