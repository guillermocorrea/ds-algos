using System;

namespace Problems.Arrays
{
    public class BinarySearchSolution
    {
        /// <summary>
        /// sorted array
        /// T: O(log n) S: O(1)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int IndexOf(int[] arr, int item)
        {
            if (arr.Length == 0) return -1;
            if (arr.Length == 1) return arr[0] == item ? 0 : -1;

            int left = 0, right = arr.Length - 1;
            while (left < right)
            {
                var middle = (int)Math.Floor((left + right) / 2m);
                if (arr[middle] == item) return middle;
                if (arr[left] == item) return left;
                if (arr[right] == item) return right;
                if (item > arr[middle])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            // left = 7, right = 12
            // arr=[1, 3, 4, 6, 7, 9, 11, 12, 15, 16, 17, 18, 19], item=15, lenght = 13
            //                           left   midlle       right
            // middle = 9
            return -1;
        }
    }
}