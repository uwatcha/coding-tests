// AIの模範回答を模写

using System;
using System.Linq;
using System.IO;

class Program
{
    static int H, W, K;
    static int[,] mapGrid;
    static bool[,] visited;
    static int maxScore = 0;

    static readonly int[] dx = {1, 0, -1, 0};
    static readonly int[] dy = {0, 1, 0, -1};

    static void Main()
    {
        #if DEBUG
        Console.SetIn(new StreamReader("input_1.txt"));
        #endif
        int[] line1Data = Console.ReadLine()
            .Trim()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        H = line1Data[0];
        W = line1Data[1];
        K = line1Data[2];

        mapGrid = new int[H,W];
        visited = new bool[H,W];

        for (int i=0; i<H; i++)
        {
            int[] lineData = Console.ReadLine()
                .Trim()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            for (int j=0; j<W; j++)
            {
                mapGrid[i,j] = lineData[j];
            }
        }

        // スタート地点に止まる。
        visited[0,0] = true;

        Dfs(0, 0, K, mapGrid[0,0]);

        Console.WriteLine(maxScore);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="steps">歩くたび減らす。0で止まる</param>
    /// <param name="currentScore"></param>
    static void Dfs(int y, int x, int steps, int currentScore)
    {
        if (steps == 0)
        {
            maxScore = Math.Max(maxScore, currentScore);
            return;
        }

        for (int i=0; i<dx.Length; i++)
        {
            int nextY = y+dy[i];
            int nextX = x+dx[i];

            if (IsInRange(nextY, H) && IsInRange(nextX, W))
            {
                bool wasVisited = visited[nextY,nextX];

                visited[nextY, nextX] = true;
                int nextScore = currentScore + (wasVisited ? 0 : mapGrid[nextY, nextX]);

                Dfs(nextY, nextX, steps-1, nextScore);

                visited[nextY, nextX] = wasVisited;
            }
        }
    }

    static bool IsInRange(int value, int max)
    {
        return 0 <= value&&value < max;
    }
}