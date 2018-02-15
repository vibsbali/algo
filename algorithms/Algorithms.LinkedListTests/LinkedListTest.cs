using System;
using System.Linq;
using Algorithms.LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.LinkedListTests
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void AddToBeginingAssertHeadEqualsTail()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.Add(1);

            Assert.IsTrue(linkedList.Count == 1);
            Assert.IsTrue(linkedList.Contains(1));
            Assert.IsTrue(linkedList.Head.Equals(linkedList.Tail));
        }

        [TestMethod]
        public void AddTwoItemsToBegining()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.Add(1);
            linkedList.AddFirst(2);

            Assert.IsTrue(linkedList.Count == 2);
            Assert.IsTrue(linkedList.Contains(1));
            Assert.IsTrue(linkedList.Contains(2));
            Assert.IsTrue(linkedList.Head.Value.Equals(2));
            Assert.IsTrue(linkedList.Tail.Value.Equals(1));
            Assert.IsFalse(linkedList.Head.Equals(linkedList.Tail));
        }

        [TestMethod]
        public void AddTwoItemsToEnd()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);

            Assert.IsTrue(linkedList.Count == 2);
            Assert.IsTrue(linkedList.Contains(1));
            Assert.IsTrue(linkedList.Contains(2));
            Assert.IsTrue(linkedList.Head.Value.Equals(1));
            Assert.IsTrue(linkedList.Tail.Value.Equals(2));
            Assert.IsFalse(linkedList.Head.Equals(linkedList.Tail));
        }
    }
}
