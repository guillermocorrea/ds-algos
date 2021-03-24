using System;
using System.Collections.Generic;
using Problems.Strings;
using Xunit;

namespace ProblemsTests.Strings
{
    public class IsPalindromeTests
    {
        [Fact]
        public void ShouldFindSolution()
        {
            // Give
            var str = "A man_ a plan. a canal: Panama";
            // When
            var result = IsPalindromeSolution.IsPalindrome(str);
            // Then
            Assert.True(result);
        }
    }
}