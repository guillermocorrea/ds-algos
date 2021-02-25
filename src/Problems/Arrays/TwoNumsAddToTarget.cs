using System;
using System.Collections.Generic;

namespace Problems.Arrays
{
    // Leet code: two sum https://leetcode.com/problems/two-sum
    public class TwoNumsAddToTargetSolution
    {
        // Given an array of integers, return the indices of two numbers
        // that add up to a given target.
        // Questions -
        // - Are all numbers positive? Yes
        // - What happens when there are more than two numbers that
        //   add up to the target? No, only one answer possible
        // - What should be returned when there are no indices that add up
        //   to the target? null
        // - Are there any duplicates? No
        // Test cases:
        // arr=[1, 3, 7, 9, 2], target=11, result=[3, 4]
        // arr=[], target=11, result=null
        // arr=[1], target=11, result=null
        // arr=[11], target=11, result=null
        // arr=[1, 3, 7, 5, 2], target=11, result=null
        // arr=[11, 0], target=11, result=[0,1]
        // Brute force solution 
        // T: O(n^2) S: O(1)
        public static int[] GetIndexesThatAddUp(int[] arr, int target)
        {
            if (arr == null || arr.Length <= 1) return null;

            for (int i = 0; i < arr.Length; i++)
            {
                var numberToFind = target - arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] == numberToFind)
                        return new int[] { i, j };
                }
            }
            return null;
        }


        /// <summary>
        /// T: O(n) S: O(n)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] GetIndexesThatAddUpOptimized(int[] nums, int target)
        {
            if (nums == null || nums.Length <= 1) return null;
            var lookupTable = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (lookupTable.ContainsKey(nums[i]))
                    return new int[] { lookupTable[nums[i]], i };
                else
                {
                    var numberToFind = target - nums[i];
                    lookupTable[numberToFind] = i;
                }
            }
            return null;
        }

        /// <summary>
        /// https://leetcode.com/problems/3sum/ T: O(n^2) S: O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3) return new List<IList<int>>();

            var result = new List<IList<int>>();
            var set = new HashSet<string>();

            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1;
                int k = nums.Length - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum == 0)
                    {
                        var key = GetHashKey(nums[i], nums[j], nums[k]);

                        if (!set.Contains(key))
                        {
                            result.Add(new List<int> { nums[i], nums[j++], nums[k--] });
                        }
                        else
                        {
                            j++;
                            k++;
                        }
                    }
                    else if (sum > 0) k--;
                    else if (sum < 0) j++;
                }
            }
            return result;
        }
        public static string GetHashKey(int i, int j, int k) => $"{i}*{j}*{k}";
    }
}