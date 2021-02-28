using System.Collections.Generic;

namespace Problems.Arrays
{
    public class FrequencyCounterSolution
    {
        /// <summary>
        /// return true if every value in the first array has it's correspoing value squared in the second array.
        /// The frequency must be the same.
        /// T: O(n) S: O(n)
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public static bool IsSquared(int[] arr1, int[] arr2)
        {
            // Check the lengths if different return false
            if (arr1.Length != arr2.Length) return false;
            // loop from 0 to arr1.Length -1
            var lookup = new Dictionary<int, int>();
            foreach (var item in arr2)
            {
                if (lookup.ContainsKey(item)) lookup[item]++;
                else lookup[item] = 1;
            }
            foreach (var item in arr1)
            {
                var squared = item * item;
                if (lookup.ContainsKey(squared) && lookup[squared] > 0)
                {
                    lookup[squared]--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}