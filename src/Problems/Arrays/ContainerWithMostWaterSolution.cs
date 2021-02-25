using System;

namespace Problems.Arrays
{
    public class ContainerWithMostWaterSolution
    {
        /// <summary>
        /// https://leetcode.com/problems/container-with-most-water/
        /// T: O(n^2) S: O(1) Brute force
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public static int ContainerWithMostWater(int[] height)
        {
            var maxArea = int.MinValue;

            for (int i = 0; i < height.Length; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    var minHeight = Math.Min(height[i], height[j]);
                    var distance = j - i;
                    var area = minHeight * distance;
                    if (area > maxArea) maxArea = area;
                }
            }
            return maxArea;
        }

        /// <summary>
        /// Two pointers shifting technique
        /// T: O(n) S: O(1)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public static int ContainerWithMostWaterOptimized(int[] height)
        {
            var maxArea = int.MinValue;

            for (int i = 0; i < height.Length; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    var minHeight = Math.Min(height[i], height[j]);
                    var distance = j - i;
                    var area = minHeight * distance;
                    if (area > maxArea) maxArea = area;
                }
            }
            return maxArea;
        }
    }
}