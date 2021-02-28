using System;
using System.Collections.Generic;

namespace Problems.Arrays
{
    public class CountUniqueValuesSolution
    {
        /// <summary>
        /// Accepts a sorted array and counts the unique values in the array.
        /// T: O(n) S: O(1)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int CountUniqueValues(int[] arr)
        {
            if (arr.Length == 0) return 0;
            if (arr.Length == 1) return 1;

            int i = 0, j = 1, uniqueValues = 0;
            while (j < arr.Length)
            {
                if (arr[i] != arr[j])
                {
                    if (uniqueValues == 0) uniqueValues = 2;
                    else uniqueValues++;
                    i = j;
                }
                j++;
            }
            return uniqueValues;
        }
    }
}