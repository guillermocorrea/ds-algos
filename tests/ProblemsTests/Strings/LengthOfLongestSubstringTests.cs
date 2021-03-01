using System;
using System.Collections.Generic;
using Problems.Strings;
using Xunit;

namespace ProblemsTests.Strings
{
    public class LengthOfLongestSubstringTests
    {
        [Fact]
        public void ShouldFindSolution()
        {
            // Given
            var str = "abcabcbb";
            // When
            var result = LengthOfLongestSubstringSolution.LengthOfLongestSubstring(str);
            // Then
            Assert.Equal(3, result);
        }
    }
}