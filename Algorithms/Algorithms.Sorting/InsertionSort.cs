using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class InsertionSort<T>
        where T : IComparable<T>
    {
        private T[] BackingStore { get; set; }
        public InsertionSort(IEnumerable<T> collectionToSort)
        {
            BackingStore = collectionToSort.ToArray();
        }

        public T[] GetSortedArray()
        {
            var startingIndex = 1;

            for (int i = startingIndex; i < BackingStore.Length; i++)
            {
                if (BackingStore[i].CompareTo(BackingStore[i - 1]) < 0)
                {
                    MoveValueFrom(i);
                }
            }

            return BackingStore;
        }

        private void MoveValueFrom(int index)
        {
            //index is the value that needs to be be moved so it is the last point
            //example 
            // |0|1|2|3|4|5|6|7|8|
            //  1 3 5 7 3 8 9 9 9
            // index is going to be 4 because item at index 4 is less than item in index 3
            var itemToInsert = BackingStore[index];
            var indexToInsertAt = GetIndexForValue(itemToInsert, index);

            Array.Copy(BackingStore, indexToInsertAt, BackingStore, indexToInsertAt + 1, index - indexToInsertAt);
            BackingStore[indexToInsertAt] = itemToInsert;
        }

        private int GetIndexForValue(T itemToInsert, int maxLengthToSearch)
        {
            for (int i = 0; i < maxLengthToSearch; i++)
            {
                if (BackingStore[i].CompareTo(itemToInsert) > 0)
                {
                    return i;
                }
            }

            return 0;
        }
    }
}
