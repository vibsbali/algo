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

        public double FillFactor => count > 0 ? backingStore.Length / count : 0;

        LinkedList<HashTableNode>[] backingStore = new LinkedList<HashTableNode>[100];

        public void Add(TKey key, TValue value)
        {
            //if backing store is 3/4 free keep inserting
            if (FillFactor > 0.75)
            {
                IncreaseBackingStore();
            }

            var index = key.GetHashCode() / backingStore.Length;

            if (backingStore[index] == null)
            {
                backingStore[index] = new LinkedList<HashTableNode>();
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
            ++count;
        }

        private void IncreaseBackingStore()
        {
            throw new NotImplementedException();
        }
    }
}

