using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Strings
{
    public class CountMinimunSwapsToMakeStringPalindrome
    {
        public static int Solve(string s)
        {
            int swaps = 0;
            var charArray = s.ToCharArray();
            int n = s.Length;
            int half = n / 2;
            char middle = default(char);
            for (int i = 0; i < half; i++) // O(n/2)
            {
                int left = i, right = n - i - 1;
                while (left < right) // O(n)
                {
                    if (charArray[left] == charArray[right])
                    {
                        break;
                    }
                    right--;
                }
                int rightLimit = n - left - 1;
                if (left == right)
                {
                    if (middle != default(char)) return -1;
                    middle = charArray[left];
                    right = left;
                    rightLimit = half;
                }
                for (int j = right; j < rightLimit; j++) // O(n)
                {
                    var tempChar = charArray[j + 1];
                    charArray[j + 1] = charArray[j];
                    charArray[j] = tempChar;
                    swaps++;
                }
            }
            return swaps;
        }
    }
}