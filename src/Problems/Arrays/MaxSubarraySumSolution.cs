using System;
using System.Collections.Generic;

namespace Problems.Arrays
{
    public class MaxSubarraySumSolution
    {
        /// <summary>
        /// Write a function which accepts an array of integers and a number called n.
        /// The function should calculate the maximun sum of n consecutive elements in the array.
        /// Sliding Window solution.
        /// T: O(n) S: O(n)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int? MaxSubarraySum(int[] arr, int n)
        {
            if (arr.Length == 0 || n > arr.Length) return null;
            if (arr.Length == 1) return arr[0];
            int windowValue = 0;
            for (int i = 0; i < n; i++)
            {
                windowValue += arr[i];
            }
            int maxSum = windowValue;
            for (int i = 1; i <= arr.Length - n; i++)
            {
                windowValue = windowValue + arr[i + n - 1] - arr[i - 1];
                if (windowValue > maxSum) maxSum = windowValue;
            }
            return maxSum;
        }
    }
}