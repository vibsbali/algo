using System;
using Algorithms.Heap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.heap.Tests
{
    [TestClass]
    public class HeapTests
    {
        [TestMethod]
        public void AddItems_Remove_Max_Assert_New_Max_At_Top()
        {
            var maxHeap = new MaxHeap<int>();
            maxHeap.Add(10);
            maxHeap.Add(6);
            maxHeap.Add(8);
            maxHeap.Add(3);
            maxHeap.Add(4);
            maxHeap.Add(5);

            var itemRemoved = maxHeap.GetMax();

            Assert.AreEqual(10, itemRemoved, "The item removed should be 10");

            var nextMax = maxHeap.Peek();

            Assert.AreEqual(8, nextMax, "The next item should be 8");
        }

        [TestMethod]
        public void AddThreeItems_In_DescendingOrder_Assert_FirstItem_Is_Largest()
        {
            var maxHeap = new MaxHeap<int>();
            maxHeap.Add(1);
            maxHeap.Add(2);
            maxHeap.Add(3);

            var itemRemoved = maxHeap.GetMax();

            Assert.AreEqual(3, itemRemoved, "The item removed should be 3");

            var nextMax = maxHeap.Peek();

            Assert.AreEqual(2, nextMax, "The next item should be 2");
        }
    }
}
