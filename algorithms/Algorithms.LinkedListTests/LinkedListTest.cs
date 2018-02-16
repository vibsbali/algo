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
        [TestCategory("AddingElements")]
        public void AddToBeginingAssertHeadEqualsTail()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.Add(1);

            Assert.IsTrue(linkedList.Count == 1);
            Assert.IsTrue(linkedList.Contains(1));
            Assert.IsTrue(linkedList.Head.Equals(linkedList.Tail));
        }

        [TestMethod]
        [TestCategory("AddingElements")]
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
        [TestCategory("AddingElements")]
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

        [TestMethod]
        [TestCategory("AddingElements")]
        public void RemoveElementsOnEmptyLinkedList()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.Add(1);

            Assert.IsTrue(linkedList.Count == 1);
            Assert.IsTrue(linkedList.Contains(1));
            Assert.IsTrue(linkedList.Head.Equals(linkedList.Tail));
        }

        [TestMethod]
        [TestCategory("AddingElements")]
        public void RemoveElementWithOneNode()
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
        [TestCategory("RemovingElements")]
        public void RemoveHead()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            Assert.IsTrue(linkedList.Count == 3);
            Assert.IsTrue(linkedList.Contains(1));
            Assert.IsTrue(linkedList.Contains(2));
            Assert.IsTrue(linkedList.Contains(3));
            Assert.IsTrue(linkedList.Head.Value.Equals(1));
            Assert.IsTrue(linkedList.Tail.Value.Equals(3));

            linkedList.Remove(1);

            Assert.IsFalse(linkedList.Head.Equals(linkedList.Tail));
            Assert.IsTrue(linkedList.Count == 2);

            Assert.IsFalse(linkedList.Contains(1));
            Assert.IsTrue(linkedList.Contains(2));
            Assert.IsTrue(linkedList.Contains(3));
            Assert.IsTrue(linkedList.Head.Value.Equals(2));
            Assert.IsTrue(linkedList.Tail.Value.Equals(3));
        }

        [TestMethod]
        [TestCategory("RemovingElements")]
        public void RemoveTail()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            Assert.IsTrue(linkedList.Count == 3);
            Assert.IsTrue(linkedList.Contains(1));
            Assert.IsTrue(linkedList.Contains(2));
            Assert.IsTrue(linkedList.Contains(3));
            Assert.IsTrue(linkedList.Head.Value.Equals(1));
            Assert.IsTrue(linkedList.Tail.Value.Equals(3));

            linkedList.Remove(3);

            Assert.IsFalse(linkedList.Head.Equals(linkedList.Tail));
            Assert.IsTrue(linkedList.Count == 2);
            Assert.IsTrue(linkedList.Contains(1));
            Assert.IsTrue(linkedList.Contains(2));
            Assert.IsFalse(linkedList.Contains(3));
            Assert.IsTrue(linkedList.Head.Value.Equals(1));
            Assert.IsTrue(linkedList.Tail.Value.Equals(2));
        }

        [TestMethod]
        [TestCategory("RemovingElements")]
        public void RemoveMiddle()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            Assert.IsTrue(linkedList.Count == 3);
            Assert.IsTrue(linkedList.Contains(1));
            Assert.IsTrue(linkedList.Contains(2));
            Assert.IsTrue(linkedList.Contains(3));
            Assert.IsTrue(linkedList.Head.Value.Equals(1));
            Assert.IsTrue(linkedList.Tail.Value.Equals(3));

            linkedList.Remove(2);

            Assert.IsFalse(linkedList.Head.Equals(linkedList.Tail));
            Assert.IsTrue(linkedList.Count == 2);
            Assert.IsTrue(linkedList.Contains(1));
            Assert.IsFalse(linkedList.Contains(2));
            Assert.IsTrue(linkedList.Contains(3));
            Assert.IsTrue(linkedList.Head.Value.Equals(1));
            Assert.IsTrue(linkedList.Tail.Value.Equals(3));
        }

        [TestMethod]
        [TestCategory("CopyingToArray")]
        public void CopyToArray()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            var sourceArray = new int[3];
            linkedList.CopyTo(sourceArray, 0);

            Assert.IsTrue(sourceArray[0] == 1);
            Assert.IsTrue(sourceArray[1] == 2);
            Assert.IsTrue(sourceArray[2] == 3);
        }
    }
}
