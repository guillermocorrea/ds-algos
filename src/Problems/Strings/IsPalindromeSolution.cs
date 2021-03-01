using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problems.Strings
{
    public class IsPalindromeSolution
    {
        public static bool IsPalindrome(string s)
        {
            if (s.Length <= 1) return true;
            s = RemoveSpecialCharacters(s).ToLower();
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9]+", "", RegexOptions.Compiled);
        }

    }
}