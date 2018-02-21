using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StackAndQueue
{
    public class Queue<T>
    {
        private T[] backingStore;
        private int Head { get; set; } = 0;
        private int Tail { get; set; } = -1;

        private int Count { get; set; }


        public Queue()
            : this(4)
        {
            
        }

        public Queue(int size)
        {
            if (size < 0)
            {
                throw new IndexOutOfRangeException();
            }

            backingStore = new T[size];
        }

        public void Enqueue(T item)
        {
            if (backingStore.Length == Count)
            {
                IncreaseBackingArray();
            }

            if (Tail == backingStore.Length - 1)
            {
                Tail = -1;
            }

            backingStore[++Tail] = item;
            ++Count;
        }

        private void IncreaseBackingArray()
        {
            var temp = new T[Count * 2];

            //Check if wrapped
            if (Head > Tail)
            {
                Array.Copy(backingStore, Head, temp, 0, backingStore.Length - Head);
                Array.Copy(backingStore, 0, temp, backingStore.Length - Head, Tail + 1);
            }
            else
            {
                Array.Copy(backingStore, Head, temp, 0, Tail + 1);
            }

            backingStore = temp;
            Head = 0;
            Tail = Count - 1;

        }

        public T Dequeue()
        {
            var itemToReturn = backingStore[Head];
            backingStore[Head] = default(T);
            Head++;

            if (Head == backingStore.Length)
            {
                Head = 0;
            }

            --Count;
            return itemToReturn;
        }

        public T Peek()
        {
            return backingStore[Head];
        }

    }
}
