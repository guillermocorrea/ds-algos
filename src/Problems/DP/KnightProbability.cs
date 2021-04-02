using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.DP
{
    public class KnightProbability
    {
        private static readonly int[][] _directions = new int[][] {
            new int[] {-1, -2},
            new int[] {1, -2},
            new int[] {-1, 2},
            new int[] {1, 2},
            new int[] {-2, -1},
            new int[] {-2, 1},
            new int[] {2, -1},
            new int[] {2, 1},
        };

        public static decimal GetKnightProbability(int n, int k, int r, int c)
        {
            var memo = new Dictionary<string, decimal>();
            return GetKnightProbabilityRecursive(n, k, r, c, memo);
        }

        private static decimal GetKnightProbabilityRecursive(int n, int k, int r, int c, Dictionary<string, decimal> memo)
        {
            var memoKey = GetKey(r, c, k);
            if (memo.ContainsKey(memoKey)) return memo[memoKey];
            // Check boundaries
            if (!(r >= 0 && r < n && c >= 0 && c < n))
            {
                return 0;
            }
            if (k == 0) return 1;
            decimal sum = 0;
            for (int i = 0; i < _directions.Length; i++)
            {
                sum += GetKnightProbabilityRecursive(n, k - 1, r + _directions[i][0], c + _directions[i][1], memo) / _directions.Length;
            }
            memo[memoKey] = sum;
            return memo[memoKey];
        }

        private static string GetKey(int r, int c, int k) => $"{r}-{c}-{k}";
    }
}