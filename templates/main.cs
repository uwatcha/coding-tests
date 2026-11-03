using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Program
{
    static void Main()
    {
        #if DEBUG
        Console.SetIn(new StreamReader("input_1.txt"));
        #endif
        int N = int.Parse(Console.ReadLine().Trim());

        Console.WriteLine(N);
    }
}
