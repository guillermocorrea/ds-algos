using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    static class Extensions
    {
        public static void PartialSort<T>(this T[] sequence, int startindex, int endindex)
        {
            sequence.Skip(startindex).Take(endindex - startindex + 1)
            .OrderBy(o => o).ToArray().CopyTo(sequence, startindex);
        }

        public static void PartialReverse<T>(this T[] sequence, int startindex, int endindex)
        {
            sequence.Skip(startindex).Take(endindex - startindex + 1).Reverse().ToArray().CopyTo(sequence, startindex);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // var input = Console.ReadLine();
            // var numCases = int.Parse(input);
            // for (int i = 1; i <= numCases; i++)
            // {
            //     var line = Console.ReadLine().Split(' ');
            //     int x = int.Parse(line[0]);
            //     int y = int.Parse(line[1]);
            //     string s = line[2];
            //     Console.WriteLine($"Case #{i}: {MinimunCost(x, y, s, 'a')}");
            // }

            Stopwatch sw = new Stopwatch();

            sw.Start();
            Console.WriteLine("Start");

            var res = GetMinimun("C?JC??J?", 2, 3);
            // GetMinimunCost(2, 3, "C?JC??J?", default(char), new Dictionary<string, int>());
            Console.WriteLine(res);

            sw.Stop();

            Console.WriteLine("Elapsed={0}", sw.Elapsed);
            // res = MinimunCost(4, 2, "CJCJ", 'a');
            // Console.WriteLine(res);
            // res = MinimunCost(1, 3, "C?J", 'a');
            // Console.WriteLine(res);
            // res = MinimunCost(2, 5, "??J???", 'a');
            // Console.WriteLine(res);

            // reversort
            // var input = Console.ReadLine();
            // var numCases = int.Parse(input);
            // for (int i = 1; i <= numCases; i++)
            // {
            //     var n = int.Parse(Console.ReadLine());
            //     var arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            //     Console.WriteLine($"Case #{i}: {CostReverSort(n, arr)}");
            // }
            // var res = CostReverSort(7, new int[] { 7, 6, 5, 4, 3, 2, 1 });
            // Console.WriteLine(res);


            // var input = Console.ReadLine();
            // var numCases = int.Parse(input);
            // for (int i = 1; i <= numCases; i++)
            // {
            //     var s = Console.ReadLine();
            //     Console.WriteLine($"Case #{i}: {SolveNestingDepth(s)}");
            // }
            // var test1 = "0000";
            // var res = SolveNestingDepth(test1);
            // Console.WriteLine(res);
            // var test2 = "101";
            // res = SolveNestingDepth(test2);
            // Console.WriteLine(res);
            // var test3 = "111000";
            // res = SolveNestingDepth(test3);
            // Console.WriteLine(res);
            // var test4 = "1";
            // res = SolveNestingDepth(test4);
            // Console.WriteLine(res);
            // var input = Console.ReadLine();
            // var numCases = int.Parse(input);

            // for (int i = 1; i <= numCases; i++)
            // {
            //     int n = int.Parse(Console.ReadLine());
            //     var matrix = new int[n][];
            //     for (int j = 0; j < n; j++)
            //     {
            //         matrix[j] = Console.ReadLine().Split(' ').Select(num => int.Parse(num)).ToArray();
            //     }
            //     Console.WriteLine($"Case #{i}: {SolveVestigium(matrix, n)}");
            // }

            // var testcase1 = new int[][] {
            //     new int[]{1, 2, 3, 4},
            //     new int[]{2, 1, 4, 3},
            //     new int[]{3, 4, 1, 2},
            //     new int[]{4, 3, 2, 1},
            // };
            // var res = SolveVestigium(testcase1, testcase1.Length);
            // Console.WriteLine(res);

            // var testcase2 = new int[][] {
            //     new int[]{2, 2, 2, 2},
            //     new int[]{2, 3, 2, 3},
            //     new int[]{2, 2, 2, 3},
            //     new int[]{2, 2, 2, 2},
            // };
            // res = SolveVestigium(testcase2, testcase2.Length);
            // Console.WriteLine(res);

            // var testcase3 = new int[][] {
            //     new int[]{2, 1, 3},
            //     new int[]{1, 3, 2},
            //     new int[]{1, 2, 3}
            // };
            // res = SolveVestigium(testcase3, testcase3.Length);
            // Console.WriteLine(res);
            // var set = new HashSet<IList<int>>();
            // set.Add(new List<int>() { 1, 2, 3 });
            // set.Add(new List<int>() { 1, 2, 3 });
            // set.Add(new List<int>() { 2, 1, 3 });

            // var list = new int[] {
            //     -1,0,1,63, 34, 7, 8, 2,-1,-4
            // };
            // Array.Sort(list);
            // var result = ThreeSum(list);
            // Console.WriteLine(PairSumSequence(2));

            // // 1 + 2 = x

            // var input = new int[] { 1, 7, 5, 9, 2, 12, 3 };
            // var pairs = PairsWithDiffKOptimized(input, 2);
            //  (1, 3), (3, 5), (5, 7), (7, 9)
        }

        static int GetMinimun(string s, int x, int y)
        {
            var combinations = GetCombinations(s);
            return combinations.Min(c => Cost(c, x, y));
        }

        static int Cost(string s, int x, int y)
        {
            var prev = default(char);
            int cost = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'C')
                {
                    if (prev == 'J')
                    {
                        // JC = y
                        cost += y;
                    }
                    // if (s.Length > 1)
                    prev = s[i];
                }
                else
                {
                    if (prev == 'C')
                    {
                        // CJ = x
                        cost += x;
                    }
                    // if (s.Length > 1)
                    prev = s[i];
                }
            }
            return cost;
        }

        static List<string> GetCombinations(string s)
        {
            HashSet<string> combinations = new HashSet<string>();
            GetCombinationsRecursive(s, combinations);
            return combinations.ToList();
        }

        static void GetCombinationsRecursive(string s, HashSet<string> combinations)
        {
            if (!s.Contains('?'))
            {
                combinations.Add(s);
                return;
            }
            var idx = s.IndexOf('?');
            GetCombinationsRecursive(s.Substring(0, idx) + "C" + s.Substring(idx + 1), combinations);
            GetCombinationsRecursive(s.Substring(0, idx) + "J" + s.Substring(idx + 1), combinations);
        }

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

        static int GetMinimunCost(int x, int y, string s, char prev, Dictionary<string, int> memo)
        {
            // if (memo.ContainsKey(s))
            // {
            //     return memo[s];
            // }
            int cost = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'C')
                {
                    if (prev == 'J')
                    {
                        // JC = y
                        cost += y;
                    }
                    // if (s.Length > 1)
                    prev = s[i];
                }
                else if (s[i] == 'J')
                {
                    if (prev == 'C')
                    {
                        // CJ = x
                        cost += x;
                    }
                    // if (s.Length > 1)
                    prev = s[i];
                }
                else
                {
                    var c = GetMinimunCost(x, y, "C" + s.Substring(i + 1), prev, memo);
                    var j = GetMinimunCost(x, y, "J" + s.Substring(i + 1), prev, memo);
                    var min = Math.Min(c, j);
                    cost += min;
                    prev = min == c ? 'C' : 'J';
                }
            }
            return cost;
        }

        // Cody Jamal
        static int MinimunCost(int x, int y, string s, char prev, Dictionary<string, int> memo)
        {
            if (memo.ContainsKey(prev + s))
                return memo[prev + s];
            if (s.Length == 1)
            {
                if (s[0] == 'C')
                {
                    if (prev == 'J')
                    {
                        return y;
                    }
                }
                else if (s[0] == 'J')
                {
                    if (prev == 'C')
                    {
                        return x;
                    }
                }
            }
            int cost = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'C')
                {
                    if (prev == 'J')
                    {
                        cost += y;
                        memo[prev + s] = cost;
                    }
                    prev = s[i];
                }
                else if (s[i] == 'J')
                {
                    if (prev == 'C')
                    {
                        cost += x;
                        memo[prev + s] = cost;
                    }
                    prev = s[i];
                }
                else
                {
                    if (i + 1 < s.Length)
                    {
                        var c = MinimunCost(x, y, "C" + s.Substring(i + 1), prev, memo);
                        var j = MinimunCost(x, y, "J" + s.Substring(i + 1), prev, memo);
                        cost += Math.Min(c, j);
                        memo[prev + s] = cost;
                    }
                    else
                    {
                        var c = MinimunCost(x, y, "C", prev, memo);
                        var j = MinimunCost(x, y, "J", prev, memo);
                        cost += Math.Min(c, j);
                        memo[prev + s] = cost;
                    }
                }
            }
            return cost;
        }

        static int CostReverSort(int n, int[] arr)
        {
            if (arr.Length <= 1) return 0;
            int cost = 0;
            for (int i = 0; i < n - 1; i++)
            {
                int minValue = int.MaxValue;
                int minPos = i;
                for (int j = i; j < n; j++)
                {
                    if (arr[j] < minValue)
                    {
                        minValue = arr[j];
                        minPos = j;
                    }
                }
                int diff = minPos - i + 1;
                arr.PartialReverse(i, minPos);
                cost += diff > 0 ? diff : 1;
            }
            return cost;
        }

        static string SolveNestingDepth(string s)
        {
            var sb = new StringBuilder();
            int openParentheses = 0;
            foreach (var numChar in s)
            {
                var currNum = int.Parse(numChar.ToString());
                if (currNum > openParentheses)
                {
                    var diff = currNum - openParentheses;
                    openParentheses += diff;
                    sb.Append(PadChar('(', diff));
                    sb.Append(numChar);
                }
                else
                {
                    var closingParentheses = openParentheses - currNum;
                    openParentheses -= closingParentheses;
                    sb.Append(PadChar(')', closingParentheses));
                    sb.Append(numChar);
                }
            }
            // Append remaining closing parentheses
            sb.Append(PadChar(')', openParentheses));
            return sb.ToString();
        }

        static string PadChar(char c, int num)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        static string SolveVestigium(int[][] matrix, int n)
        {
            int trace = 0, numberOfRows = 0, numberOfCols = 0;
            for (int row = 0; row < n; row++)
            {
                trace += matrix[row][row];
                // check rows
                var seenRow = new HashSet<int>();
                for (int col = 0; col < n; col++)
                {
                    var num = matrix[row][col];
                    if (seenRow.Contains(num))
                    {
                        numberOfRows++;
                        break;
                    }
                    else { seenRow.Add(num); }
                }
                // check cols
                var seenCol = new HashSet<int>();
                for (int rowIdx = 0; rowIdx < n; rowIdx++)
                {
                    var num = matrix[rowIdx][row];
                    if (seenCol.Contains(num))
                    {
                        numberOfCols++;
                        break;
                    }
                    else { seenCol.Add(num); }
                }
            }
            return $"{trace} {numberOfRows} {numberOfCols}";
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
