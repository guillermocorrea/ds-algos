using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.Strings;
using Xunit;

namespace ProblemsTests.Strings
{
    public class CountMinimunSwapsToMakeStringPalindromeTests
    {
        [Fact]
        public void CanSolve()
        {
            // Given
            var s = "aabcb";
            // When
            var result = CountMinimunSwapsToMakeStringPalindrome.Solve(s);
            Assert.Equal(3, result);

            Assert.Equal(3, CountMinimunSwapsToMakeStringPalindrome.Solve("mamad"));

            Assert.Equal(-1, CountMinimunSwapsToMakeStringPalindrome.Solve("asflkj"));

            Assert.Equal(2, CountMinimunSwapsToMakeStringPalindrome.Solve("aabb"));

            Assert.Equal(1, CountMinimunSwapsToMakeStringPalindrome.Solve("ntiin"));


            // Input: "aabb"
            // Output: 2
            // Example 4:

            // Input: "ntiin"
            // Output: 1
            // Explanation: swap 't' with 'i' => "nitin"
        }
    }
}