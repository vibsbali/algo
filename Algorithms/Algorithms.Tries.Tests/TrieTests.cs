using System;
using System.Collections.Generic;
using System.Linq;
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

        [TestMethod]
        public void Add_and_autocomplete_and()
        {
            var trie = new Trie(256);
            trie.Add("and");

            var found = trie.Find("and");
            Assert.IsTrue(found, "and should have been found");

            var completedWords = trie.GenerateAutocomplete("a");
            Assert.IsNotNull(completedWords);

            Assert.AreEqual("and", completedWords[0]);
        }

        [TestMethod]
        public void Add_and_autocomplete_and_an_apple_annie()
        {
            var trie = new Trie(256);
            var words = new List<string>
            {
                "and",
                "an",
                "apple",
                "annie"
            };
            foreach (var word in words)
            {
                trie.Add(word);
            }




            var completedWords = trie.GenerateAutocomplete("a");
            Assert.IsNotNull(completedWords);

            foreach (var completedWord in completedWords)
            {
                Assert.IsTrue(words.Contains(completedWord));
            }
        }

        [TestMethod]
        public void Add_and_autocomplete_apple_banana_angie_angela_kamila_aarav_Asset_words_starting_with_a()
        {
            var trie = new Trie(256);
            var words = new List<string>
            {
                "apple",
                "banana",
                "angie",
                "angela",
                "kamila",
                "aarav"
            };

            foreach (var word in words)
            {
                trie.Add(word);
            }

            var completedWords = trie.GenerateAutocomplete("a");
            Assert.IsNotNull(completedWords);

            foreach (var completedWord in completedWords)
            {
                Assert.IsTrue(words.Where(w => w.StartsWith("a")).Contains(completedWord));
            }

            foreach (var completedWord in completedWords)
            {
                Assert.IsFalse(words.Where(w => w.StartsWith("b")).Contains(completedWord));
            }
        }

        [TestMethod]
        public void Add_and_autocomplete_apple_banana_angie_angela_kamila_aarav_Asset_words_starting_with_b()
        {
            var trie = new Trie(256);
            var words = new List<string>
            {
                "apple",
                "banana",
                "angie",
                "angela",
                "kamila",
                "aarav"
            };

            foreach (var word in words)
            {
                trie.Add(word);
            }

            var completedWords = trie.GenerateAutocomplete("b");
            Assert.IsNotNull(completedWords);

            foreach (var completedWord in completedWords)
            {
                Assert.IsTrue(words.Where(w => w.StartsWith("b")).Contains(completedWord));
            }

            foreach (var completedWord in completedWords)
            {
                Assert.IsFalse(words.Where(w => w.StartsWith("a")).Contains(completedWord));
            }
        }

        [TestMethod]
        public void Add_and_autocorrect_apple_banana_angie_angela_banano()
        {
            var trie = new Trie(256);
            var wordsNotToBeFound = new List<string>
            {
                "abcd",
                "dedf"
            };

            var words = new List<string>
            {
                "abc",
                "gem",
                "ann",
                "and",
                "kim"
            };

            foreach (var word in words)
            {
                trie.Add(word);
            }

            foreach (var wordNotTobeFound in wordsNotToBeFound)
            {
                trie.Add(wordNotTobeFound);
            }

            var incorrectWord = "jim";
            var wordsFound = trie.GetAutocorrections(incorrectWord, 4);

            Assert.IsTrue(wordsFound.Contains("abc"));
        }

        [TestMethod]
        public void Add_and_autocorrect_swone_to_stone()
        {
            var trie = new Trie(256);
            var wordsNotToBeFound = new List<string>
            {
                "abcd",
                "dedf"
            };

            var words = new List<string>
            {
                "stone",
              
            };

            foreach (var word in words)
            {
                trie.Add(word);
            }

            foreach (var wordNotTobeFound in wordsNotToBeFound)
            {
                trie.Add(wordNotTobeFound);
            }

            var incorrectWord = "swone";
            var wordsFound = trie.GetAutocorrections(incorrectWord, 1);

            Assert.IsTrue(wordsFound.Contains("stone"));
        }
    }
}
