using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.LinkedLists;
using Xunit;

namespace ProblemsTests.LinkedLists
{
    public class FindCycleTests
    {
        [Fact]
        public void ShouldFindSolution()
        {
            // Given
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            var node3 = new ListNode(3);
            head.next.next = node3;
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = node3;
            // When
            var result = FindCycleSolution.FindCycle(head);
            // Then
            Assert.True(result);
        }

        [Fact(Skip = "Fix")]
        public void ShouldFindOptimalSolution()
        {
            // Given
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            var node3 = new ListNode(3);
            head.next.next = node3;
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = node3;
            // When
            var result = FindCycleSolution.FindCycleOptimal(head);
            // Then
            Assert.NotNull(result);
            Assert.Equal(node3, result);
        }
    }
}