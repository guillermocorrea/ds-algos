using System;
using System.Collections.Generic;

namespace Problems.Strings
{
    public class CharCountSolution
    {
        public static Dictionary<char, int> CharCount(string str)
        {
            // Create dictionary to hold frequency of each character
            var map = new Dictionary<char, int>();
            // loop through string
            foreach (var currentCharacter in str)
            {
                if (!Char.IsLetterOrDigit(currentCharacter)) continue;
                var lowercaseChar = Char.ToLower(currentCharacter);
                if (map.ContainsKey(lowercaseChar)) map[lowercaseChar]++;
                else map[lowercaseChar] = 1;
            }

            // return dictionary at the end
            return map;
        }

        private static bool IsValidChar(char character)
        {
            return true;
        }
    }
}