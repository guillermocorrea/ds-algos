using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.LinkedLists
{
    public class ReverseBetweenSolution
    {
        /// https://leetcode.com/problems/reverse-linked-list-ii/
        /// t: O(n) s: O(1)
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            var curr = head;
            int idx = 1;
            ListNode prev = null, nodeBeforeWindow = null;
            while (idx < left)
            {
                nodeBeforeWindow = curr;
                curr = curr.next;
                idx++;
            }
            var tail = curr;
            while (idx >= left && idx <= right)
            {
                var next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
                idx++;
            }
            if (nodeBeforeWindow != null) nodeBeforeWindow.next = prev;
            if (prev != null && curr != null)
            {
                tail.next = curr;
            }

            while (idx > right && curr != null)
            {
                curr = curr.next;
                idx++;
            }

            if (left > 1) return head;
            return prev;
        }
    }
}