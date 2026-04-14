using System;
using System.IO;
using System.Collections.Generic;

public class MainApp
{

    static public void Main(string[] args)
    {
        // このコードは標準入力と標準出力を用いたサンプルコードです。
        // このコードは好きなように編集・削除してもらって構いません。

        var lines = GetStdin();

        int arrayALength = Int32.Parse(lines[0]);
        string[] arrayA = ConvertTextToArray(lines[1], false);
        arrayA = TrimArrayWithLength(arrayA, arrayALength);

        int arrayBLength = Int32.Parse(lines[2]);
        string[] arrayB = ConvertTextToArray(lines[3], true);
        arrayB = TrimArrayWithLength(arrayB, arrayBLength);

        CountAndOutput(arrayA, arrayB);
    }

    static private string[] GetStdin()
    {
        var list = new List<string>();
        string line;
        while ((line = Console.ReadLine()) != null)
        {
            list.Add(line);
        }
        //TODO: 入力ルール検知
        


        return list.ToArray();
    }

    //配列を入力した行から、文字の配列を取得する
    static private string[] ConvertTextToArray(string text, bool isDuplicatable)
    {
      if (!isDuplicatable)
      {
        var checkerText = new string(text.ToCharArray().Distinct().ToArray());
        if (!text.Equals(checkerText))
        {
          Console.WriteLine("配列Aに重複した文字が含まれています。");
          return null;
        }
      }
      string[] array = String.Split(text);
      //TODO: 各要素が小文字アルファベット1文字か確認
      return array;
    }

    //指定された長さで配列の要素を削る
    static private string[] TrimArrayWithLength(string[] array, int length)
    {
      string[] newArray;
      Array.Copy(array, 0, newArray, length);
      return newArray;
    }

    static private void CountAndOutput (string[] arrayA, string[] arrayB)
    {
      //1. 一度B内のアルファベット全てを計測する
      //2. その後、Aに含まれるものだけ残す

      Dictionary<string, int> arrayBCount = new();
      foreach (string letter in arrayB)
      {
        if (arrayB.Contains(letter))
        {
          arrayBCount[letter] = arrayBCount[letter] + 1;
        }
        else
        {
          arrayBCount.Add(letter, 1);
        }
      }

      foreach (KeyValuePair<string, int> e in arrayB)
      {
        if (arrayA.Keys.Contains(e.Key))
        {
          Console.WriteLine(GetOutputLine(e));
        }
      }
    }

    static private void GetOutputLine(KeyValuePair<string, int> result)
    {
      return $"{result.Key}:{result.Value}";
    }
}