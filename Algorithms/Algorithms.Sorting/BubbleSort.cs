using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class BubbleSort<T>
        where T : IComparable<T>
    {
        public T[] CollectionToSort { get; set; }
        public BubbleSort(IEnumerable<T> collectionToSort)
        {
            CollectionToSort = collectionToSort.ToArray();
        }

        public T[] GetSortedArray()
        {
            var didSort = true;
            var i = 0;

            while (didSort)
            {
                didSort = false;
                for (int k = 0; k < CollectionToSort.Length - 1 - i; k++)
                {
                    if (CollectionToSort[k].CompareTo(CollectionToSort[k + 1]) > 0)
                    {
                        CollectionToSort.Swap(k, k + 1);
                        didSort = true;
                    }
                }
                ++i;
            }

            return CollectionToSort;
        }
    }
}
