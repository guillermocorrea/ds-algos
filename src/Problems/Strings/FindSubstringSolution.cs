using System;

namespace Problems.Strings
{
    public class FindSubstringSolution
    {
        public static int FindSubstringCount(string str, string shortStr)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < shortStr.Length; j++)
                {
                    if (shortStr[j] != str[i + j]) break;
                    if (j == shortStr.Length - 1) count++;
                }
            }
            return count;
        }
    }
}