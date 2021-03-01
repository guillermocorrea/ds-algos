using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.LinkedLists
{
    public class ReverseLinkedListSolution
    {
        /// <summary>
        /// https://leetcode.com/problems/reverse-linked-list/submissions/
        /// t: O(n) s: O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode ReverseList(ListNode head)
        {
            var currentNode = head;
            ListNode prev = null;
            while (currentNode != null)
            {
                var next = currentNode.next;
                currentNode.next = prev;
                prev = currentNode;
                currentNode = next;
            }
            return prev;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}