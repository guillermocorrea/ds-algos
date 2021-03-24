using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.DataStructures.Stack
{
    public class ValidParenthesesSolution
    {
        /// <summary>
        /// Easy, Valid Parentheses https://leetcode.com/problems/valid-parentheses/
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ValidParentheses(string str)
        {
            if (string.IsNullOrEmpty(str)) return true;
            var parenthesesLookup = new Dictionary<char, char>
            {
                {'{', '}'},
                {'(', ')'},
                {'[', ']'}
            };
            var openingParentheses = new Stack<char>();
            foreach (var parentheses in str)
            {
                if (parenthesesLookup.ContainsKey(parentheses))
                {
                    // opening parentheses
                    openingParentheses.Push(parentheses);
                }
                else
                {
                    // closing parentheses
                    if (openingParentheses.Count == 0 || parenthesesLookup[openingParentheses.Pop()] != parentheses)
                    {
                        return false;
                    }
                }
            }
            return openingParentheses.Count == 0;
        }
    }
}