using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Heap
{
    public class MaxHeap<T>
        where T : IComparable<T>
    {
        List<T> backingStore = new List<T>();
        public int Count { get; private set; }
        public void Add(T item)
        {
            if (backingStore.Count == Count)
            {
                backingStore.Add(default(T));
            }

            backingStore[Count++] = item;

            BalanceTree(Count - 1);
        }

        private void BalanceTree(int indexInsertedAt)
        {
            if (indexInsertedAt <= 0)
            {
                return;
            }

            var itemValue = backingStore[indexInsertedAt];

            var parentIndex = GetParentIndex(indexInsertedAt);
            var parentValue = backingStore[parentIndex];

            //If parent is smaller than child
            if (parentIndex >= 0 && indexInsertedAt >= 0 && parentValue.CompareTo(itemValue) < 0)
            {
                Swap(parentIndex, indexInsertedAt);
                BalanceTree(parentIndex);
            }
        }

        private int GetParentIndex(int indexInsertedAt)
        {
            return (indexInsertedAt - 1) / 2;
        }

        public T Peek()
        {
            return backingStore[0];
        }

        public T GetMax()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("empty collection store");
            }

            var itemToReturn = backingStore[0];

            //move the last item from the backing
            var lastIndex = Count - 1;
            backingStore[0] = backingStore[lastIndex];
            backingStore[lastIndex] = default(T);
            --Count;

            //
            var index = 0;
            int leftChild = (2 * index) + 1;
            int rightChild = (2 * index) + 2;
            while (index < Count && leftChild < Count && rightChild < Count)
            {
                var newParent = NewParent(index, leftChild, rightChild);
                //check if both children are smaller
                if (newParent == -1)
                {
                    break;
                }

                index = newParent;
                leftChild = (2 * index) + 1;
                rightChild = (2 * index) + 2;
            }

            return itemToReturn;
        }

        //method that swap the value if the parent is smaller
        //if swap is not performed then -1 is returned to indicate that rotation is not required
        private int NewParent(int index, int leftChild, int rightChild)
        {
            var leftChildValue = backingStore[leftChild];
            var rightChildValue = backingStore[rightChild];
            var parentValue = backingStore[index];

            //find out which one is maximum left or right and then only swap with maximum of the two child
            if (leftChildValue.CompareTo(rightChildValue) > 0)
            {
                //is parent smaller than 
                if (parentValue.CompareTo(leftChildValue) < 0)
                {
                    Swap(index, leftChild);
                    return leftChild;
                }
            }
            else if (leftChild.CompareTo(rightChild) < 0)
            {
                //right is bigger than left
                if (parentValue.CompareTo(rightChildValue) < 0)
                {
                    Swap(index, rightChild);
                    return rightChild;
                }
            }
            //TODO can we have same values in the backing store

            return -1;
        }

        private void Swap(int first, int second)
        {
            var temp = backingStore[first];
            backingStore[first] = backingStore[second];
            backingStore[second] = temp;
        }
    }
}
