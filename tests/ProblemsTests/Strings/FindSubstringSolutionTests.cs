using System;
using Problems.Strings;
using Xunit;

namespace ProblemsTests.Strings
{
    public class FindSubstringSolutionTests
    {
        [Theory]
        [InlineData("lorain loled", "lol", 1)]
        [InlineData("lorain loled", "loled", 1)]
        [InlineData("lorain loled", "lo", 2)]
        [InlineData("lorain loled", "lox", 0)]
        public void ShouldFindSolution(string str, string shortStr, int expected)
        {
            var result = FindSubstringSolution.FindSubstringCount(str, shortStr);
            Assert.Equal(expected, result);
        }
    }
}