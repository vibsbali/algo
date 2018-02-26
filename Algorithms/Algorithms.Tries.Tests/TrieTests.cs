using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tries.Tests
{
    [TestClass]
    public class TrieTests
    {
        [TestMethod]
        public void Can_Add_And()
        {
            var trie = new Trie(256);
            trie.Add("and");

            var found = trie.Find("and");
            Assert.IsTrue(found, "and should have been found");

            var notFound = trie.Find("angus");
            Assert.IsFalse(notFound, "angus is not added therefore should have not been found");
        }
    }
}
