using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

class Program
{

    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var numCases = int.Parse(input);
        for (int i = 1; i <= numCases; i++)
        {
            var line = Console.ReadLine().Split(' ');
            int x = int.Parse(line[0]);
            int y = int.Parse(line[1]);
            string s = line[2];
            Console.WriteLine($"Case #{i}: {GetMinimun(s, default(char), x, y, new Dictionary<string, int>())}");
        }
    }

    static int GetMinimun(string s, char prev, int x, int y, Dictionary<string, int> memo)
    {
        if (memo.ContainsKey($"{prev},{s}"))
        {
            return memo[$"{prev},{s}"];
        }
        int cost = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'J')
            {
                if (prev == 'C')
                {
                    // CJ
                    cost += x;
                }
                prev = s[i];
            }
            else if (s[i] == 'C')
            {
                if (prev == 'J')
                {
                    // JC
                    cost += y;
                }
                prev = s[i];
            }
            else
            {
                var sWithC = "C" + s.Substring(i + 1);
                var costWithC = GetMinimun(sWithC, prev, x, y, memo);
                memo[$"{prev},{sWithC}"] = costWithC;

                var sWithJ = "J" + s.Substring(i + 1);
                var costWithJ = GetMinimun(sWithJ, prev, x, y, memo);
                memo[$"{prev},{sWithJ}"] = costWithJ;

                cost += Math.Min(costWithC, costWithJ);
                return cost;
            }
        }
        return cost;
    }
}