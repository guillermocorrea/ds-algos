using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ProblemsTests.DataStructures.Trie
{
    public class TrieTests
    {
        [Fact]
        public void CanSolve()
        {
            // Given
            var trie = new Problems.DataStructures.Tries.Trie();
            // When
            trie.Insert("apple");
            Assert.False(trie.Search("dog"));
            trie.Insert("dog");
            Assert.True(trie.Search("dog"));
            Assert.True(trie.StartsWith("app"));
            trie.Insert("app");
            Assert.True(trie.Search("app"));
            Assert.True(trie.StartsWith("app"));
            // Then

        }
    }
}