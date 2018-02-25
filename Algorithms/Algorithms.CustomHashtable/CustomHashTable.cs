using System;
using System.Collections.Generic;

namespace Algorithms.CustomHashtable
{
    public class CustomHashTable<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        internal class HashTableNode
        {
            public HashTableNode(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            public TKey Key { get; }
            public TValue Value { get; private set; }
        }

        private int count;

        public double FillFactor => count > 0 ? count / backingStore.Length : 0;

        LinkedList<HashTableNode>[] backingStore = new LinkedList<HashTableNode>[1];

        public void Add(TKey key, TValue value)
        {
            //if backing store is 3/4 free keep inserting
            if (FillFactor > 0.75)
            {
                IncreaseBackingStore();
            }

            var index = GetIndex(key);

            if (backingStore[index] == null)
            {
                backingStore[index] = new LinkedList<HashTableNode>();
                ++count;
            }

            var currentNode = backingStore[index].First;
            while (currentNode != null)
            {
                if (currentNode.Value.Key.Equals(key))
                {
                    throw new InvalidOperationException("Cannot insert same key");
                }
                currentNode = currentNode.Next;
            }

            backingStore[index].AddLast(new HashTableNode(key, value));
        }

        private int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % backingStore.Length;
        }

        private int GetIndex(TKey key, int length)
        {
            return Math.Abs(key.GetHashCode()) % length;
        }


        private void IncreaseBackingStore()
        {
            var tempStore = new LinkedList<HashTableNode>[backingStore.Length * 2];
            for (int i = 0; i < backingStore.Length; i++)
            {
                if (backingStore[i] != null)
                {
                    var key = backingStore[i].First.Value.Key;
                    var newIndex = GetIndex(key, tempStore.Length);

                    if (tempStore[newIndex] == null)
                    {
                        tempStore[newIndex] = new LinkedList<HashTableNode>();
                    }

                    foreach (var hashTableNode in backingStore[i])
                    {
                        tempStore[newIndex].AddLast(hashTableNode);
                    }
                }
            }

            backingStore = tempStore;
        }

        public bool Contains(TKey key)
        {
            var index = GetIndex(key);

            if (backingStore[index] != null)
            {
                var currentNode = backingStore[index].First;
                while (currentNode != null)
                {
                    if (currentNode.Value.Key.Equals(key))
                    {
                        return true;
                    }

                    currentNode = currentNode.Next;
                }
            }

            return false;
        }

        public TValue GetElement(TKey key)
        {
            var index = GetIndex(key);

            if (backingStore[index] != null)
            {
                LinkedListNode<HashTableNode> currentNode = backingStore[index].First;
                while (currentNode != null)
                {
                    if (currentNode.Value.Key.Equals(key))
                    {
                        return currentNode.Value.Value;
                    }

                    currentNode = currentNode.Next;
                }
            }

            throw new InvalidOperationException("No key/value pair found");
        }
    }
}

