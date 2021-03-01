using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Strings
{
    public class LengthOfLongestSubstringSolution
    {
        // https://leetcode.com/problems/longest-substring-without-repeating-characters/
        public static int LengthOfLongestSubstring(string s)
        {
            // Sliding window, t: O(n), s: O(n)
            if (s.Length <= 1) return s.Length;
            var lookup = new Dictionary<char, int>();
            int longest = 0, left = 0;

            for (int right = 0; right < s.Length; right++)
            {
                var currentChar = s[right];
                if (lookup.ContainsKey(currentChar) && lookup[currentChar] >= left)
                {
                    left = lookup[currentChar] + 1;
                }
                lookup[currentChar] = right;
                longest = Math.Max(longest, right - left + 1);
            }
            return longest;

            // Brute force t: O(n^2), s: O(n)
            /*if (s.Length == 0) return 0;
            if (s.Length == 1) return 1;
            int maxCount = 0;
            for (int i = 0; i < s.Length; i++) {
                var frequencies = new Dictionary<char, int>();
                frequencies[s[i]] = 1;
                var count = 1;
                int j;
                for (j = i + 1; j < s.Length; j++) {
                    if (frequencies.ContainsKey(s[j])) break;
                    count++;
                    frequencies[s[j]] = 1;
                }
                if (count > maxCount) maxCount = count;
                // i = j - 2;
            }
            return maxCount;*/
        }
    }
}