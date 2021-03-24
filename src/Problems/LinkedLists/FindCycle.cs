using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.LinkedLists
{
    public class FindCycleSolution
    {
        /// <summary>
        /// Linked List Cycle https://leetcode.com/problems/linked-list-cycle/
        /// T: O(n) S: O(n)
        /// </summary>
        /// <param name="head"></param>
        public static bool FindCycle(ListNode head)
        {
            if (head == null || head.next == null) return false;
            var visitedNodes = new Dictionary<ListNode, bool>();
            var current = head;
            while (!visitedNodes.ContainsKey(current))
            {
                Console.Write(current.val + " ");
                if (current.next == null) return false;
                visitedNodes[current] = true;
                current = current.next;
            }
            return true;
        }

        /// <summary>
        /// T: O(n) S: O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode FindCycleOptimal(ListNode head)
        {
            if (head == null || head.next == null) return null;
            ListNode node = head;
            ListNode fastBro = head;
            while (fastBro != null && fastBro.next != null)
            {
                fastBro = fastBro.next.next;
                node = node.next;
                if (fastBro == node)
                {
                    return fastBro;
                }
            }
            var p1 = head;
            var p2 = fastBro;
            while (true)
            {
                if (p1 == p2) break;
                p1 = p1.next;
                p2 = p2.next;
            }
            return p1;
        }
    }
}