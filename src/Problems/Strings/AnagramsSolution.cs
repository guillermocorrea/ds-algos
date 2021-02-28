using System;
using System.Collections.Generic;

namespace Problems.Strings
{
    public class AnagramsSolution
    {
        /// <summary>
        /// Given two strings, write a function to determine if the second string is an anagram of the first.
        /// An anagram is a word, phrase or name formed by rearranging the letters of another, such as 'cinema',
        /// formed from 'iceman'.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool IsAnagram(string str1, string str2)
        {
            if (str1 == str2) return true;
            if (str1.Length != str2.Length) return false;

            var lookup = new Dictionary<char, int>();
            foreach (var token in str1)
            {
                if (lookup.ContainsKey(token)) lookup[token]++;
                else lookup[token] = 1;
            }
            foreach (var token in str2)
            {
                if (!lookup.ContainsKey(token) || lookup[token] == 0) return false;
                if (lookup.ContainsKey(token)) lookup[token]--;
            }
            return true;
        }
    }
}