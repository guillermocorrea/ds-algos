using System;
using Problems.Strings;
using Xunit;

namespace ProblemsTests.Strings
{
    public class AnagramsSolutionTests
    {
        [Theory]
        [InlineData("", "", true)]
        [InlineData("ab", "ab", true)]
        [InlineData("anagram", "nagaram", true)]
        [InlineData("rat", "car", false)]
        [InlineData("qwerty", "qeywrt", true)]
        [InlineData("texttwisttime", "timetwisttext", true)]
        public void ShouldFindSolution(string str1, string str2, bool expected)
        {
            // When
            var result = AnagramsSolution.IsAnagram(str1, str2);
            // Then
            Assert.Equal(expected, result);
        }
    }
}