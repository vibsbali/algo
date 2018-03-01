using System;
using System.Runtime;
using System.Threading;
using Algorithms.Heap;

namespace Algorithms.PriorityQueue
{
    /*
     * Priority Queue  
     * A priority queue is a cross between a queue and heap. It looks and feels like a queue—items can be enqueued and dequeued. 
     * However, the value that is returned is the highest priority item.  
     * Priority queues are commonly used in scenarios where many items are being processed, some of which are more important than others. 
 
     * Priority Queue Class  
     * The priority queue class is a very thin wrapper over a heap. All it really does is wrap the Add and RemoveMax methods with
     * Enqueue and Dequeue, respectively. 
     */
    public class PriorityQ<T>
        where T : IComparable<T>
    {
        private readonly MaxHeap<T> heap;
        public PriorityQ()
        {
            heap = new MaxHeap<T>();
        }
        public void Enqueue(T value)
        {
            heap.Add(value);
        }

        public int Count => heap.Count;

        public T Dequeue()
        {
            return heap.GetMax();
        }

        public T Peek()
        {
            return heap.Peek();
        }
    }
}
