using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ArrayList
{
    public class ArrayList<T> : IList<T>
    where T : IComparable<T>
    {
        private T[] backingStore;
        private readonly int initialSize;

        public ArrayList(int size = 0)
        {
            if (size <= 0)
            {
                initialSize = 4;
            }
            else
            {
                initialSize = size;
            }

            backingStore = new T[initialSize];
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return backingStore[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (Count == backingStore.Length)
            {
                GrowBackingStore();
            }

            backingStore[Count++] = item;
        }

        private void GrowBackingStore()
        {
            var currentSize = backingStore.Length;
            var tempStore = new T[currentSize * 2];

            Array.Copy(backingStore, 0, tempStore, 0, Count);
            backingStore = tempStore;
        }

        public void Clear()
        {
            backingStore = new T[initialSize];
            Count = 0;
        }

        public bool Contains(T item)
        {
            if (this.IndexOf(item) != -1)
            {
                return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            var indexOfItemToRemove = this.IndexOf(item);
            if (indexOfItemToRemove == -1)
            {
                return false;
            }

            for (int i = indexOfItemToRemove; i < Count; i++)
            {
                backingStore[i] = backingStore[indexOfItemToRemove + 1];
            }

            --Count;
            return true;
        }

        public int Count { get; private set; }
       
        public bool IsReadOnly => false;
        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (backingStore[i].CompareTo(item) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        //Can't add items outside the bounds ie. greater than count
        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}
