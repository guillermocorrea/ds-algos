using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Search
{
    public class BinarySearch
    {
        public static int FindBinarySearch(int[] arr, int target)
        {
            if (arr.Length == 0) return -1;
            int leftIdx = 0, rightIndex = arr.Length - 1;
            while (leftIdx <= rightIndex)
            {
                int medium = (leftIdx + rightIndex) / 2;
                if (arr[medium] == target) return medium;
                if (arr[medium] < target)
                {
                    leftIdx = medium + 1;
                }
                else
                {
                    rightIndex = medium - 1;
                }
            }

            return -1;
        }

        public static int FindBinarySearch(int[] arr, int startIndex, int endIndex, int target)
        {
            if (arr.Length == 0) return -1;
            int leftIdx = startIndex, rightIndex = endIndex;
            while (leftIdx <= rightIndex)
            {
                int medium = (int)Math.Floor((leftIdx + rightIndex) / 2m);
                if (arr[medium] == target) return medium;
                if (arr[medium] < target)
                {
                    leftIdx = medium + 1;
                }
                else
                {
                    rightIndex = medium - 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// [1, 3, 3, 5, 5, 5, 8, 9] t=5 => [3, 5]
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] GetStartingAndEndingIndexOfTarget(int[] arr, int target)
        {
            if (arr.Length == 0) return new int[] { -1, -1 };
            var mid = FindBinarySearch(arr, 0, arr.Length - 1, target);
            if (mid == -1) return new int[] { -1, -1 };
            int leftTemp = mid;
            int rightTemp = mid;
            int midTemp = mid;
            int right = mid - 1;
            int left = 0;
            while (midTemp != -1)
            {
                midTemp = FindBinarySearch(arr, left, right, target);
                if (midTemp != -1)
                {
                    leftTemp = midTemp;
                    left = midTemp + 1;
                }
            }
            midTemp = 0;
            left = mid + 1;
            right = arr.Length - 1;
            while (midTemp != -1)
            {
                midTemp = FindBinarySearch(arr, left, right, target);
                if (midTemp != -1)
                {
                    rightTemp = midTemp;
                    left = midTemp + 1;
                }
            }

            return new int[] { leftTemp, rightTemp };
        }
    }
}