using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.DataStructures.queue
{
    public class ValidadParentheses2
    {
        /// <summary>
        ///hard, 301. Remove Invalid Parentheses https://leetcode.com/problems/remove-invalid-parentheses/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> RemoveInvalidParentheses(string str)
        {
            if (string.IsNullOrEmpty(str)) return new List<string>();
            var queue = new Queue<int>();
            var result = new List<string>();
            var listToRemove = new List<int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    queue.Enqueue(i);
                }
                else if (str[i] == ')')
                {
                    if (queue.Count == 0)
                    {
                        listToRemove.Add(i);
                    }
                    else
                    {
                        queue.Dequeue();
                    }
                }
            }
            int counter = 0;
            var tempStr = str;
            foreach (var item in listToRemove)
            {
                tempStr = tempStr.Remove(item - counter++, 1);
            }
            while (queue.Count > 0)
            {
                tempStr = tempStr.Remove(queue.Dequeue() - counter++, 1);
            }
            return result;
        }

        /// <summary>
        /// T: O(n) S: O(n)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveMinimunParentheses(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            var queue = new Queue<int>();
            string result = str;
            var listToRemove = new List<int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    queue.Enqueue(i);
                }
                else if (str[i] == ')')
                {
                    if (queue.Count == 0)
                    {
                        listToRemove.Add(i);
                    }
                    else
                    {
                        queue.Dequeue();
                    }
                }
            }
            int counter = 0;
            foreach (var item in listToRemove)
            {
                result = result.Remove(item - counter++, 1);
            }
            while (queue.Count > 0)
            {
                result = result.Remove(queue.Dequeue() - counter++, 1);
            }
            return result;
        }
    }
}