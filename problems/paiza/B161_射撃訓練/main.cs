using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        string[] line1 = Console.ReadLine().Trim().Split(' ');
        int Height = int.Parse(line1[0]);
        int Width = int.Parse(line1[1]);
        Print("Height", Height);
        Print("Width", Width);

        int Number = int.Parse(Console.ReadLine().Trim());

        Dictionary<(int, int), int> pointTable = new Dictionary<(int, int), int>();
        List<(int, int)> surroundOffsets = new List<(int, int)>()
        {
            (-1, -1), (-1, 0), (-1, 1),
            (0, -1), (0, 0), (0, 1),
            (1, -1), (1, 0), (1, 1)
        };
        for (int i=0; i<Number; i++)
        {
            string[] line = Console.ReadLine().Trim().Split(' ');
            int row = int.Parse(line[0])-1;
            int col = int.Parse(line[1])-1;
            int p_center = int.Parse(line[2]);
            int p_surround = int.Parse(line[3]);
            Print("row", row);
            Print("col", col);
            Print("p_center", p_center);
            Print("p_surround", p_surround);
            foreach(var offset in surroundOffsets)
            {
                int point = offset.Equals((0, 0)) ? p_center : p_surround;
                int pos_r = row+offset.Item1;
                int pos_c = col+offset.Item2;
                Print("point", point);
                Print("pos_r", pos_r);
                Print("pos_c", pos_c);
                if (IsInRange(pos_r, 0, Height) && IsInRange(pos_c, 0, Width))
                {
                    pointTable.Add((pos_r, pos_c), point);
                    Print("Add", -1);
                }
                else
                {
                    Print("THRU", -1);
                }
            }
        }

        int ShootCount = int.Parse(Console.ReadLine().Trim());
        int sumScore = 0;
        for (int i=0; i<ShootCount; i++)
        {
            string[] line = Console.ReadLine().Trim().Split(' ');
            var shootPos = (int.Parse(line[0])-1, int.Parse(line[1])-1);
            Print("shootPos", (int.Parse(line[0])-1)+", "+(int.Parse(line[1])-1));
            if (pointTable.ContainsKey(shootPos))
            {
                sumScore += pointTable[shootPos];
                Print("Count", -1);
            }
        }
        Console.WriteLine(sumScore);
    }

    static bool IsInRange (int value, int min, int max)
    {
        if (value < min)
        {
            return false;
        }
        else if (value >= max)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    static void Print(string label, object value)
    {
        // Console.WriteLine(label+": "+value);
    }
}