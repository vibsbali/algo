using System;

namespace Algorithms.Sorting
{
    public static class SortingExtensions
    {
        public static void Swap<T>(this T[] array, int firstPosition, int secondPosition)
        {
            var temp = array[firstPosition];
            array[firstPosition] = array[secondPosition];
            array[secondPosition] = temp;
        }

        public static bool IsSorted<T>(this T[] array)
            where T : IComparable<T>
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i].CompareTo(array[i + 1]) > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
