using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Arrays
{
    /// <summary>
    /// Largest K such that both K and -K exist in array
    /// Write a function that, given an array A of N integers, returns the lagest integer K > 0 such that both values K and -K exist in array A. If there is no such integer, the function should return 0.

    /// Example 1:

    /// Input: [3, 2, -2, 5, -3]
    /// Output: 3
    /// Example 2:

    /// Input: [1, 2, 3, -4]
    /// Output: 0
    /// </summary>
    public class LargestKInArray
    {
        public static int GetLargestK(int[] input)
        {
            if (input.Length <= 1) return 0;
            var descComparer = Comparer<int>.Create((a, b) => b.CompareTo(a));
            var sortedSet = new SortedSet<int>(input, descComparer);
            foreach (var item in input)
            {
                if (sortedSet.Contains(-item)) return item;
            }
            return 0;
        }
    }
}