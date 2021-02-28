using System;
using System.Text;

namespace Problems.Strings
{
    /// <summary>
    /// https://leetcode.com/problems/backspace-string-compare/
    /// </summary>
    public class AreEqualSolution
    {
        public static bool AreEqual(string s, string t)
        {
            var resultS = Transform(s);
            var resultT = Transform(t);
            return resultS == resultT;
        }

        // T: O(n) S: O(n)
        // video 28
        private static string Transform(string s)
        {
            var sb = new StringBuilder("");
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '#')
                {
                    if (sb.Length > 0)
                        sb.Remove(sb.Length - 1, 1);
                }
                else
                {
                    sb.Append(s[i]);
                }
            }
            return sb.ToString();
        }
    }
}