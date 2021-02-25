using System;
namespace Problems.Arrays
{
    public class TrappingRainWaterSolution
    {
        /// <summary>
        /// https://leetcode.com/problems/trapping-rain-water/
        /// T: O(n^2) S: O(1)
        /// </summary>
        public static int Trap(int[] height)
        {
            if (height.Length < 2) return 0;
            int total = 0;
            for (int i = 0; i < height.Length; i++)
            {
                int maxLeft = 0, maxRight = 0;
                int leftIndex = i - 1, rightIndex = i + 1;
                while (leftIndex >= 0)
                {
                    maxLeft = height[leftIndex] > maxLeft ? height[leftIndex] : maxLeft;
                    leftIndex--;
                }
                while (rightIndex < height.Length)
                {
                    maxRight = height[rightIndex] > maxRight ? height[rightIndex] : maxRight;
                    rightIndex++;
                }

                var currentWater = Math.Min(maxLeft, maxRight) - height[i];
                if (currentWater > 0) total += currentWater;
            }
            return total;
        }

        /// <summary>
        /// Two pointers technique T: O(n) S: O(1)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public static int TrapOptimized(int[] height)
        {
            if (height.Length < 2) return 0;
            int total = 0;
            int maxLeft = height[0], maxRight = height[height.Length - 1], left = 0, right = height.Length - 1;
            var min = Math.Min(maxLeft, maxRight);
            int i = left;
            if (min == maxRight) i = right;
            while (left < right)
            {
                if (height[left] > maxLeft) maxLeft = height[left];
                if (height[right] > maxRight) maxRight = height[right];

                var currentWater = Math.Min(maxLeft, maxRight) - height[i];

                if (currentWater > 0) total += currentWater;

                if (height[left] < height[right])
                {
                    left++;
                    i = left;
                }
                else
                {
                    right--;
                    i = right;
                }
            }
            return total;
        }
    }
}