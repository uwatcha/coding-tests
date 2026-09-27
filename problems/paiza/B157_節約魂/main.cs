//リンク：
//ギブアップ 
//よく見たら、「それぞれの野菜について、他店と同じ値段で販売されていることはない」という条件を見逃して、複雑に考えすぎていた。


using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] line1 = Console.ReadLine().Trim().Split(' ');
        int N = int.Parse(line1[0]);
        int K = int.Parse(line1[1]);

        Dictionary<int, List<int>> VegesByShop = new Dictionary<int, List<int>>();

        Dictionary<int, List<int>> ShopsByVege = new Dictionary<int, List<int>>();
        for (int i=0; i<K; i++)
        {
            ShopsByVege.Add(i, new List<int>());
        }

        for (int i=0; i<N; i++)
        {
            string[] line = Console.ReadLine().Trim().Split(' ');
            for (int j=0; j<K; j++)
            {
                List<int> lineData = new List<string>(line).ConvertAll<int>(x => int.Parse(x));
                VegesByShop.Add(i, lineData);
                ShopsByVege[j].Add(lineData[i]);
            }
        }




        // <vege, shop>
        Dictionary<int, int> = BuyShopByVeges = new Dictionary<int, int>();
        
        for (int i=0; i<K; i++)
        {
            List<int> shops = ShopsByVege[i];
            int min = shops.Min;
            List<int> cheapShops = shops.Where(x => x==min).ToList();
        }
    }
}
//TODO
//各野菜の最安テンポの「一覧」を作る
//各店舗の最安となった野菜の一覧と、その数を数える
//決め方
//野菜の数がmaxの店舗がある->1
//各野菜をどの店舗で買うか決める必要がある
//最安店舗のうち、最安の野菜数が多い店舗を選ぶ