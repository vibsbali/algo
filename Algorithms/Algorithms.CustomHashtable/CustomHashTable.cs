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

        LinkedList<HashTableNode>[] backingStore = new LinkedList<HashTableNode>[100];

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

        private void IncreaseBackingStore()
        {
            throw new NotImplementedException();
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


    }
}

