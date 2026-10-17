/*
1. Rだけを見て、目標のRを作れるか全ての組み合わせを試す
2. 作れたら、その条件を満たす色をペア(複数ペアを想定)を保存し、次の工程、作れなかったらNoを出力
3. 各ペアのG、Bをみて、目標のG,Bを作れるかけんさ
4. 作れたら、Yesを出力、作れなかったら、次のペアを検査。全てのペアで作れなかったらNoを出力
*/
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Color targetColor = lineToColor(Console.ReadLine()!);

        int N = int.Parse(Console.ReadLine()!.Trim());

        List<Color> colors = new List<Color>();
        for (int i = 0; i<N; i++)
        {
            Color color = lineToColor(Console.ReadLine()!);
            colors.Add(color);
        }

        // takeCountごとに組み合わせを求める
        for (int i = 1; i<N+1; i++)
        {
            Console.WriteLine("GetColorCombinations("+i+")");
            GetColorCombinations(colors, i);
        }
        // GetColorCombinations(colors, 2);
    }

    static Color lineToColor(string line)
    {
        List<int> lineData = line.Trim().Split(' ').ToList().Select(x => int.Parse(x)).ToList();
        Color color = new Color(lineData[0], lineData[1], lineData[2]);
        color.PrintLine();
        return color;
    }

    /// <summary>
    /// 指定した個数の色の組み合わせを求めます。
    /// </summary>
    /// <param name="parentList">組み合わせ元の色の一覧。</param>
    /// <param name="takeCount">組み合わせる色の個数。</param>
    static void GetColorCombinations(List<Color> parentList, int takeCount)
    {
        int n = parentList.Count;
        int r = takeCount;
        List<int> indexes = new List<int>(new int[r]);
        //CHECK: Selectは元のListを書き換えるわけではない。
        indexes.Select(x=>x=0);
        Recurse(parentList, indexes, n, r, 0, 0);
    }

    /// <summary>
    /// 色の組み合わせを再帰的に探索します。
    /// </summary>
    /// <param name="parentList">組み合わせ元の色の一覧。</param>
    /// <param name="indexes">選択中の色のインデックス。</param>
    /// <param name="n">色の総数。</param>
    /// <param name="r">選択する色の個数。</param>
    /// <param name="i">現在処理している矢印の番号。</param>
    /// <param name="v">現在の矢印が指すインデックス。</param>
    static void Recurse(List<Color> parentList, List<int> indexes, int n, int r, int i, int v)
    {
        Console.WriteLine("Recurse("+i+", "+v+")");
        // Console.WriteLine("first set.");
        // indexを定める
        // SetArrow(parentList, indexes, i, v);
        // 次のindexを指定する
        // 今扱う矢印(i)が、r本目の時は、
        if (i + 1 == r)
        {
            // Console.WriteLine("selecting arrow is last one.");
            Console.WriteLine("n-v: "+n+"-"+v+"="+(n-v));
            // r本目の矢印を最後まで動かす。
            for (int j = 0; j < n-v; j++)
            {
                // Console.WriteLine("last arrow is moving to end");
                SetArrow(parentList, indexes, i, v+j);
            }
            // 矢印が最後まで移動したら
            if (IsFinish(indexes, n, r))
            {
                Console.WriteLine("all finish");
                return;
            }
            else
            {
                // r-1本目の矢印を、1つ下にずらす
                // Console.WriteLine("bottom arrow exe is finish. before arrow recurse start.");
                Recurse(parentList, indexes, n, r, i - 1, indexes[i - 1] + 1);
            }
        }
        else
        {
            // Console.WriteLine("selecting arrow is Not last one.");
            // Console.WriteLine("this arrow set.");
            SetArrow(parentList, indexes, i, v);
            if(IsFinish(indexes, n, r))
            {
                Console.WriteLine("all finish");
                return;
            }
            else
            {
                // Console.WriteLine("next arrow recurse start.");
                Recurse(parentList, indexes, n, r, i + 1, indexes[i] + 1);
            }
        }
    }
    static void SetArrow(List<Color> parentList, List<int> indexes, int i, int v)
    {
        // Console.WriteLine("SetArrow("+i+", "+v+")");
        Console.WriteLine("Arrow(" + i + ") -> (" + v + ")" + parentList[v].ToString());
        indexes[i] = v;
    }
    static bool IsFinish(List<int> indexes, int n, int r)
    {
        return indexes[0] == n - r && indexes[r - 1] == n - 1;
    }
}

class Color
{
    private int r;
    private int g;
    private int b;
    public int R => r;
    public int G => g;
    public int B => b;

    public Color(int r, int g, int b)
    {
        this.r = r;
        this.g = g;
        this.b = b;
    }
    public override string ToString()
    {
        return "(" + r + ", " + g + ", " + b + ")";
    }
    public void PrintLine()
    {
        Console.WriteLine(ToString());
    }
}