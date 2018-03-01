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
                var queue = new Queue<TrieNodes>();
                queue.Enqueue(currentNode);
                wordsToReturn.AddRange(GetWord(queue));

            }

            return wordsToReturn.ToArray();
        }

        private string[] GetWord(Queue<TrieNodes> currentQueueNodes)
        {
            var potentialStrings = new List<string>();
            if (currentQueueNodes == null)
            {
                throw new InvalidOperationException();
            }

            while (currentQueueNodes.Count > 0)
            {
                var currentNode = currentQueueNodes.Dequeue();
                if (!string.IsNullOrWhiteSpace(currentNode.Value))
                {
                    potentialStrings.Add(currentNode.Value);
                }

                foreach (var nodes in currentNode.Nodes.Where(n => n != null))
                {
                    currentQueueNodes.Enqueue(nodes);
                }
            }

            return potentialStrings.ToArray();
        }

        //This method is stupidly slow just for practice only and incomplete
        //Should be using edit distance algorithm
        public string[] GetAutocorrections(string wordToCheck, int numberOfWordsToFind = 4)
        {
            if (!Find(wordToCheck))
            {
                var listOfWordsFound = new List<string>();
                var queueOfstringsToExplore = new Queue<string>();
                queueOfstringsToExplore.Enqueue(wordToCheck);

                while (queueOfstringsToExplore.Any() && listOfWordsFound.Count < numberOfWordsToFind)
                {
                    var currentWord = queueOfstringsToExplore.Dequeue();
                    var charArray = currentWord.ToCharArray();

                    //Replace each character from a-z to check if new word can be found
                    // canana -> aanana -> banana -> danana followed by cbnana ccnana cdnana cenanan etc.
                    for (int i = 0; i < charArray.Length; i++)
                    {
                        foreach (var alphabet in CompleteAlphabets)
                        {
                            var newWord = currentWord.SwapAt(i, alphabet);
                            if (Find(newWord) && !listOfWordsFound.Contains(newWord))
                            {
                                listOfWordsFound.Add(newWord);
                            }

                            queueOfstringsToExplore.Enqueue(newWord);
                        }
                    }

                    //Remove one character at a time to check of new word can be made
                    //canana -> anana -> nana -> ana -> na followed by cnana -> cana -> cna -> ca followed by caana -> cana -> cna etc

                    //Add one character at a time to check of new word can be made
                    //kangaro -> akangaro -> bkangaro -> ckangaro -> etc followed by kaangaro -> kbangro -> kcangro -> etc followed by kangaro -> kangaroo 
                }

                return listOfWordsFound.ToArray();
            }

            return new[] { wordToCheck };
        }

        public char[] CompleteAlphabets => new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    }
}
