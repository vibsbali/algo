using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.SortingTests
{
    [TestClass]
    public class InsertionSortTests
    {
        [TestMethod]
        public void SortedArray_Assert_IsSorted_True()
        {
            var arrayToTest = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Assert.IsTrue(arrayToTest.IsSorted());
        }

        [TestMethod]
        public void SortedArray_Assert_IsSorted_False()
        {
            var arrayToTest = new[] { 1, 2, 4, 3, 5, 6, 7, 8, 9, 10 };
            Assert.IsFalse(arrayToTest.IsSorted());
        }

        [TestMethod]
        public void SortArray_Simple_Random()
        {
            var arrayToTest = new[] { 1, 2, 4, 3, 5, 6, 7, 8, 9, 10 };
            var insertionSort = new InsertionSort<int>(arrayToTest);
            arrayToTest = insertionSort.GetSortedArray();
            Assert.IsTrue(arrayToTest.IsSorted());
        }

        [TestMethod]
        public void SortArray_Extreme_Random()
        {
            var arrayToTest = new[] { 1, 10, 9, 7, 6, 5, 10, 8, 1, 0 };
            var insertionSort = new InsertionSort<int>(arrayToTest);
            arrayToTest = insertionSort.GetSortedArray();
            Assert.IsTrue(arrayToTest.IsSorted());
        }


        [TestMethod]
        public void SortArray_Decreasing_Values()
        {
            var arrayToTest = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            var insertionSort = new InsertionSort<int>(arrayToTest);
            arrayToTest = insertionSort.GetSortedArray();
            Assert.IsTrue(arrayToTest.IsSorted());
        }
    }
}
