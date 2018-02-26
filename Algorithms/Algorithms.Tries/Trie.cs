using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tries
{
    public class Trie
    {
        readonly TrieNodes[] _roots;
        private readonly int _radix;

        public Trie(int radix)
        {
            this._radix = radix;
            _roots = new TrieNodes[radix];
        }

        public void Add(string word)
        {
            var charArray = word.ToLower().ToCharArray();

            //simple initialisation to ensure that the root is initialised
            if (_roots[charArray[0]] == null)
            {
                _roots[charArray[0]] = new TrieNodes(_radix);
            }

            var currentNode = _roots[charArray[0]];
            for (var i = 0; i < charArray.Length; i++)
            {
                if (currentNode.Nodes[charArray[i]] == null)
                {
                    currentNode.Nodes[charArray[i]] = new TrieNodes(_radix);
                }

                currentNode = currentNode.Nodes[charArray[i]];
            }

            currentNode.Value = word;
        }

        public bool Find(string wordToFind)
        {
            var charArray = wordToFind.ToLower().ToCharArray();
            var currentNode = _roots[charArray[0]];
            var i = 0;

            while (currentNode != null && i != charArray.Length)
            {
                currentNode = currentNode.Nodes[charArray[i]];
                i++;
            }

            if (currentNode == null)
            {
                return false;
            }

            return currentNode.Value.Equals(wordToFind.ToLower());
        }

        public string[] GenerateAutocomplete(string wordToComplete)
        {
            List<string> wordsToReturn = new List<string>();
            var charArray = wordToComplete.ToLower().ToCharArray();
            var currentNode = _roots[charArray[0]];
            var i = 0;

            //Loop to get to the final node from where to start the search
            while (currentNode != null && i != charArray.Length)
            {
                currentNode = currentNode.Nodes[charArray[i]];
                i++;
            }

            if (currentNode != null)
            {
                foreach (var currentNodeNode in currentNode.Nodes.Where(n => n != null))
                {
                    wordsToReturn.AddRange(GetWord(currentNodeNode));
                }
            }

            throw new NotImplementedException();
        }

        private string[] GetWord(TrieNodes currentNodeNode)
        {
            var potentialStrings = new List<string>();
            if (currentNodeNode == null)
            {
                throw new InvalidOperationException();
            }

            if (!string.IsNullOrWhiteSpace(currentNodeNode.Value))
            {
                potentialStrings.Add(currentNodeNode.Value);
            }


        }
    }
}
