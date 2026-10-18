using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Program
{
    static int H, W, K;
    static void Main()
    {
        #if DEBUG
        Console.SetIn(new StreamReader("input_2.txt"));
        #endif
        string[] line1Data = Console.ReadLine().Trim().Split(' ');
        H = int.Parse(line1Data[0]);
        W = int.Parse(line1Data[1]);
        K = int.Parse(line1Data[2]);

        int[,] mapGridSource = new int[H,W];
        for (int i=0; i<H; i++)
        {
            int[] lineData = Console.ReadLine().Trim().Split(' ').Select(x=>int.Parse(x)).ToArray();
            for (int j=0; j<W; j++)
            {
                mapGridSource[i,j] = lineData[j];
            }
        }

        for (int i=0; i<H*W; i++)
        {
            int[,] mapGrid = new int[H,W];
            Array.Copy(mapGridSource, mapGrid, mapGridSource.Length);
            int sum = 0;

            int startY = i/W;
            int startX = i%W;
            sum = HandleGetCoin(mapGrid, startY, startX, sum);
            Move(mapGrid, startY, startX);
        }
    }

    static void Move(int[,] mapGrid, int y, int x)
    {
        var tmp =  GetNextDirection(y, x);
        int nextY = tmp.Item1;
        int nextX = tmp.Item2;
        if (CanMove(mapGrid, nextY, nextX))
        {
            Move(mapGrid, nextY, nextX);
        }
    }
    static bool CanMove(int[,] mapGrid, int nextY, int nextX)
    {
        bool isInRangeY = 0 <= nextY&&nextY < H;
        bool isInRangeX = 0 <= nextX&&nextX < W;
        return isInRangeY && isInRangeX && mapGrid[nextY, nextX] != -1;
    }
    static Tuple<int, int> GetNextDirection(int y, int x)
    {
        //TODO: 前回の移動の方向を参照し、右に90度回転させた方向を返す
        Tuple<int, int> rtn = new Tuple<int, int>(1, 0);
        return rtn;
    }
    static int HandleGetCoin(int[,] mapGrid, int y, int x, int sum)
    {
        int point = mapGrid[y,x];
        mapGrid[y,x] = -1;
        return sum + point;
    }

    static void Print(string label, object value)
    {
        Console.WriteLine(label + ": " + value);
    }

    static void PrintElements(string label, IEnumerable values)

    {
        string valueText = string.Join(", ", values);
        Console.WriteLine(label + ": " + valueText);
    }
}