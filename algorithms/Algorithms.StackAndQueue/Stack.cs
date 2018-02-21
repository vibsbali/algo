using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StackAndQueue
{
    public class Stack<T>
    {
        private T[] backingStore;
        private int Head { get; set; }
        private int Count { get; set; }

        public Stack()
            : this(4)
        {   
        }

        public Stack(int size)
        {
            if (size < 0)
            {
                throw new IndexOutOfRangeException();
            }

            backingStore = new T[size];
        }

        public void Push(T item)
        {
            if (Count == backingStore.Length)
            {
                GrowBackingStore();
            }

            backingStore[Head++] = item;
            Count++;
        }


        private void GrowBackingStore()
        {
            var currentSize = backingStore.Length;
            var tempStore = new T[currentSize * 2];

            Array.Copy(backingStore, 0, tempStore, 0, Count);
            backingStore = tempStore;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            var item = backingStore[--Head];
            --Count;

            return item;
        }

        public T Peek()
        {
            return backingStore[Head - 1];
        }
    }
}
