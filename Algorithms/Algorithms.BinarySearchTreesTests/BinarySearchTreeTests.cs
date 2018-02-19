using System;
using Algorithms.BinarySearchTrees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.BinarySearchTreesTests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        [TestMethod]
        public void InitialiseNewTree_Assert_Count_Zero()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            Assert.AreEqual(0, binarySearchTree.Count);
            Assert.IsNotNull(binarySearchTree);
        }

        [TestMethod]
        public void InitialiseNewTree_AddOneItem_Assert_Count_One()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);

            Assert.AreEqual(1, binarySearchTree.Count);
            Assert.IsNotNull(binarySearchTree);
            Assert.AreEqual(100, binarySearchTree.Head.Value);
        }


        [TestMethod]
        public void InitialiseNewTree_AddThreeItems_Of_DifferentValue__Assert_Count_Three_And_Check_Left_Right()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);
            binarySearchTree.Add(75);
            binarySearchTree.Add(125);

            Assert.AreEqual(3, binarySearchTree.Count);
            Assert.IsNotNull(binarySearchTree);
            Assert.AreEqual(100, binarySearchTree.Head.Value);
            Assert.AreEqual(75, binarySearchTree.Head.LeftChild.Value);
            Assert.AreEqual(125, binarySearchTree.Head.RightChild.Value);
        }

        [TestMethod]
        public void InitialiseNewTree_AddThreeItems_Of_SameValue_Assert_Count_Three_And_Check_Left_Right()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);
            binarySearchTree.Add(75);
            binarySearchTree.Add(100);

            Assert.AreEqual(3, binarySearchTree.Count);
            Assert.IsNotNull(binarySearchTree);
            Assert.AreEqual(100, binarySearchTree.Head.Value);
            Assert.AreEqual(75, binarySearchTree.Head.LeftChild.Value);
            Assert.AreEqual(100, binarySearchTree.Head.RightChild.Value);
        }

    }
}
