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
        Console.SetIn(new StreamReader("input_1.txt"));
#endif
        int[] line1Data = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
        H = line1Data[0];
        W = line1Data[1];
        K = line1Data[2];

        int[] dx = [1, 0, -1, 0];
        int[] dy = [0, 1, 0, -1];

        int[,] mapGrid = new int[H,W];
        bool[,] visited = new bool[H,W];
        for (int i=0; i<H; i++)
        {
            int[] lineData = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
            for (int j=0; j<W; j++)
            {
                mapGrid[i,j] = lineData[j];
                visited[i,j] = false;
            }
        }

        Dfs(mapGrid, visited, 0, 0, K, 0);
    }

    static void Dfs(int[,] mapGrid, bool[,] visited, int y, int x, int steps, int currentScore)
    {
        if (steps>0 && IsInRange(y, H) && IsInRange(x, W))
        {
            if (!visited[y,x])
            {
                int scoreSum = currentScore+mapGrid[y,x];
                visited[y,x] = true;
            }
            Dfs();
        }
    }

    static bool IsInRange(int value, int max)
    {
        return 0 <= value&&value < max;
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