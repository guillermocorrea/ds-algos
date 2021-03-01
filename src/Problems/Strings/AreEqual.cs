using System;
using System.Text;

namespace Problems.Strings
{
    /// <summary>
    /// https://leetcode.com/problems/backspace-string-compare/
    /// </summary>
    public class AreEqualSolution
    {
        /// <summary>
        /// T: O(a + b)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool AreEqual(string s, string t)
        {
            var resultS = Transform(s);
            var resultT = Transform(t);
            return resultS == resultT;
        }

        public static bool AreEqualOptimal(string s, string t)
        {
            // TODO: Fix
            int p1 = s.Length - 1, p2 = t.Length - 1;
            while (p1 >= 0 || p2 >= 0)
            {
                if (s[p1] == '#' || t[p2] == '#')
                {
                    bool hashP1 = false;
                    while (p1 >= 0 && s[p1] == '#')
                    {
                        p1--;
                        hashP1 = true;
                    }
                    if (hashP1) p1--;
                    bool hashP2 = false;
                    while (p2 >= 0 && t[p2] == '#')
                    {
                        p2--;
                        hashP2 = true;
                    }
                    if (hashP2) p2--;
                }
                if (p1 >= 0 && p2 >= 0 && s[p1] != t[p2]) return false;
                p1--;
                p2--;
            }
            return true;
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