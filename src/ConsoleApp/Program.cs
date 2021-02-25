using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        public static void SetZeroes(int[][] matrix)
        {
            int columnsLen = matrix.Length;
            int rowsLen = matrix[0].Length;
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3) return new List<IList<int>>();
            // Array.Sort(nums);
            // Brute force approach
            var result = new List<IList<int>>();
            for (int x = 0; x < nums.Length; x++)
            {
                int xVal = nums[x];
                for (int y = 0; y < nums.Length; y++)
                {
                    if (y == x) continue;
                    int yVal = nums[y];
                    for (int z = 0; z < nums.Length; z++)
                    {
                        if (z == x || z == y) continue;
                        int zVal = nums[z];
                        if (xVal + yVal + zVal == 0)
                        {
                            // TODO: check unique values
                            result.Add(new List<int> { xVal, yVal, zVal });
                        }
                    }
                }
            }

            return result;
            /*
                Input: nums = [-1,0,1,2,-1,-4]
                Output: [[-1,-1,2],[-1,0,1]]

                loop i = 1; i < nums.length - 1; i++
                    initial = nums[i - 1]    
                    x = nums[i]
                    loop j = 2; j < nums.length - 2; j ++
                        y = nums[j]
                        if (initial + x + y == 0)
                           result.add([initial, x, y]) 


            */
        }
        static void Main(string[] args)
        {
            var set = new HashSet<IList<int>>();
            set.Add(new List<int>() { 1, 2, 3 });
            set.Add(new List<int>() { 1, 2, 3 });
            set.Add(new List<int>() { 2, 1, 3 });

            var list = new int[] {
                -1,0,1,2,-1,-4
            };
            var result = ThreeSum(list);
            Console.WriteLine(PairSumSequence(2));

            // 1 + 2 = x

            var input = new int[] { 1, 7, 5, 9, 2, 12, 3 };
            var pairs = PairsWithDiffKOptimized(input, 2);
            //  (1, 3), (3, 5), (5, 7), (7, 9)
        }

        // O(n^2)
        public static IList<(int, int)> PairsWithDiffKBruteForce(int[] arr, int k)
        {
            var result = new List<(int, int)>();
            int len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                var curr = arr[i];
                for (int j = i + 1; j < len; j++)
                {
                    var next = arr[j];
                    if (Math.Abs(curr - next) == k)
                        result.Add((curr, next));
                }
            }
            return result;
        }

        // O(n)
        public static IList<(int, int)> PairsWithDiffKOptimized(int[] arr, int k)
        {
            var result = new List<(int, int)>();
            int len = arr.Length;
            var visited = new Dictionary<int, int>();
            foreach (var item in arr)
            {
                visited[item] = item;
            }
            for (int i = 0; i < len; i++)
            {
                var curr = arr[i];
                var x = curr + k;
                if (visited.ContainsKey(x))
                    result.Add((curr, x));
            }
            return result;
        }

        public static int PairSumSequence(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += Sum(i, i + 1);
            }
            return sum;
        }

        public static int Sum(int a, int b) => a + b;
    }
}
