using System;
using System.Collections.Generic;
using Problems.Strings;
using Xunit;

namespace ProblemsTests.Strings
{
    public class CharCountTests
    {
        public void ShouldFindSolution()
        {
            // Give
            var str = "Hi There! 12 12";
            // When
            var result = CharCountSolution.CharCount(str);
            // Then
            Dictionary<char, int> expected = new Dictionary<char, int>() {
                 {'h', 2},
                 {'i', 1},
                 {'t', 1},
                 {'e', 2},
                 {'r', 1}
            };
            Assert.Equal(result, expected);
        }
    }
}