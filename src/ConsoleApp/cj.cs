// using System;
// class Program
// {

//     static void Main(string[] args)
//     {
//         var input = Console.ReadLine();
//         var numCases = int.Parse(input);
//         for (int i = 1; i <= numCases; i++)
//         {
//             var line = Console.ReadLine().Split(' ');
//             int x = int.Parse(line[0]);
//             int y = int.Parse(line[1]);
//             string s = line[2];
//             Console.WriteLine($"Case #{i}: {MinimunCost(x, y, s, 'a')}");
//         }
//     }

//     static int MinimunCost(int x, int y, string s, char prev)
//     {
//         int cost = 0;
//         for (int i = 0; i < s.Length; i++)
//         {
//             if (s[i] == 'C')
//             {
//                 if (prev == 'J')
//                 {
//                     cost += y;
//                 }
//             }
//             else if (s[i] == 'J')
//             {
//                 if (prev == 'C')
//                 {
//                     cost += x;
//                 }
//             }
//             else
//             {
//                 if (i + 1 < s.Length)
//                 {
//                     cost += Math.Min(MinimunCost(x, y, "C" + s.Substring(i + 1), prev), MinimunCost(x, y, "J" + s.Substring(i + 1), prev));
//                 }
//                 else
//                 {
//                     cost += Math.Min(MinimunCost(x, y, "C", prev), MinimunCost(x, y, "J" + s.Substring(i + 1), prev));
//                 }
//             }
//             prev = s[i];
//         }
//         return cost;
//     }
// }