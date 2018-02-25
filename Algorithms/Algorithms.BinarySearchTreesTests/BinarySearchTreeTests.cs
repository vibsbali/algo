using Algorithms.BinarySearchTrees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            Assert.IsTrue(binarySearchTree.Contains(100));
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

            Assert.IsTrue(binarySearchTree.Contains(100));
            Assert.IsTrue(binarySearchTree.Contains(75));
            Assert.IsTrue(binarySearchTree.Contains(125));
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

            Assert.IsTrue(binarySearchTree.Contains(100));
            Assert.IsTrue(binarySearchTree.Contains(75));
            Assert.IsTrue(binarySearchTree.Contains(100));
        }

        [TestMethod]
        public void InitialiseNewTree_With_One_Node_Remove_Node_Assert_Count_Zero_Head_Null()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);

            binarySearchTree.Remove(100);
            Assert.IsNull(binarySearchTree.Head);
            Assert.AreEqual(0, binarySearchTree.Count);
        }

        [TestMethod]
        public void InitialiseNewTree_With_Three_Nodes_Remove_Tail_Right_Of_Parent_Assert_Count_Of_Two()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);
            binarySearchTree.Add(75);
            binarySearchTree.Add(125);

            binarySearchTree.Remove(125);
            Assert.AreEqual(2, binarySearchTree.Count);
            Assert.IsNull(binarySearchTree.Head.RightChild);
        }

        [TestMethod]
        public void InitialiseNewTree_With_Three_Nodes_Remove_Tail_Left_Of_Parent_Assert_Count_Of_Two()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);
            binarySearchTree.Add(75);
            binarySearchTree.Add(125);

            binarySearchTree.Remove(75);
            Assert.AreEqual(2, binarySearchTree.Count);
            Assert.IsNull(binarySearchTree.Head.LeftChild);
        }

        [TestMethod]
        public void InitialiseNewTree_With_Two_Nodes_Remove_Head_Assert_Count_Of_One_And_New_Head()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);
            binarySearchTree.Add(75);

            binarySearchTree.Remove(100);
            Assert.AreEqual(1, binarySearchTree.Count);

            Assert.AreEqual(75, binarySearchTree.Head.Value);
            Assert.IsNull(binarySearchTree.Head.RightChild);
            Assert.IsNull(binarySearchTree.Head.LeftChild);
        }

        [TestMethod]
        public void InitialiseNewTree_With_Five_Nodes_Remove_Node_Left_Of_Parent_Which_Doesnt_Have_Right_Node_But_Has_left_node()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);
            binarySearchTree.Add(75);
            binarySearchTree.Add(125);
            binarySearchTree.Add(50);
            binarySearchTree.Add(115);

            binarySearchTree.Remove(75);
            Assert.AreEqual(4, binarySearchTree.Count);
            Assert.IsNotNull(binarySearchTree.Head.LeftChild);
            Assert.AreEqual(50, binarySearchTree.Head.LeftChild.Value);
        }

        [TestMethod]
        public void InitialiseNewTree_With_Five_Nodes_Remove_Node_Right_Of_Parent_Which_Doesnt_Have_Right_Node_But_Has_left_node()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);
            binarySearchTree.Add(75);
            binarySearchTree.Add(125);
            binarySearchTree.Add(50);
            binarySearchTree.Add(115);

            binarySearchTree.Remove(125);
            Assert.AreEqual(4, binarySearchTree.Count);
            Assert.IsNotNull(binarySearchTree.Head.RightChild);
            Assert.AreEqual(115, binarySearchTree.Head.RightChild.Value);
        }


        [TestMethod]
        [TestCategory("Node to remove has a right child which doesn't has a left child")]
        public void InitialiseNewTree_With_Five_Nodes_Remove_Head_Heads_RightChild_Has_No_Left_Child()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);
            binarySearchTree.Add(75);
            binarySearchTree.Add(125);
            binarySearchTree.Add(50);
            binarySearchTree.Add(135);

            binarySearchTree.Remove(100);
            Assert.AreEqual(4, binarySearchTree.Count);
            Assert.AreEqual(125, binarySearchTree.Head.Value); ;
            Assert.AreEqual(135, binarySearchTree.Head.RightChild.Value);
        }

        [TestMethod]
        [TestCategory("Node to remove has a right child which doesn't has a left child")]
        public void InitialiseNewTree_With_Seven_Nodes_Remove_Node_Left_Of_Parent_Whos_RightChild_Has_No_Left_Child()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);
            binarySearchTree.Add(75);
            binarySearchTree.Add(125);
            binarySearchTree.Add(50);
            binarySearchTree.Add(85);
            binarySearchTree.Add(135);
            binarySearchTree.Add(95);


            binarySearchTree.Remove(75);
            Assert.AreEqual(6, binarySearchTree.Count);
            Assert.AreEqual(85, binarySearchTree.Head.LeftChild.Value); ;
            Assert.AreEqual(50, binarySearchTree.Head.LeftChild.LeftChild.Value); ;
            Assert.AreEqual(95, binarySearchTree.Head.LeftChild.RightChild.Value);
        }

        [TestMethod]
        [TestCategory("Node to remove has a right child which doesn't has a left child")]
        public void InitialiseNewTree_With_Seven_Nodes_Remove_Node_Right_Of_Parent_Whos_RightChild_Has_No_Left_Child()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);
            binarySearchTree.Add(75);
            binarySearchTree.Add(125);
            binarySearchTree.Add(115);
            binarySearchTree.Add(135);
            binarySearchTree.Add(145);
            binarySearchTree.Add(155);


            binarySearchTree.Remove(125);
            Assert.AreEqual(6, binarySearchTree.Count);
            Assert.AreEqual(135, binarySearchTree.Head.RightChild.Value); ;
            Assert.AreEqual(115, binarySearchTree.Head.RightChild.LeftChild.Value); ;
            Assert.AreEqual(145, binarySearchTree.Head.RightChild.RightChild.Value);
        }


        [TestMethod]
        [TestCategory("Node to remove has a right child which has a left child")]
        public void InitialiseNewTree_With_Seven_Nodes_Remove_Head()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);
            binarySearchTree.Add(75);
            binarySearchTree.Add(125);
            binarySearchTree.Add(115);
            binarySearchTree.Add(135);
            binarySearchTree.Add(145);
            binarySearchTree.Add(155);


            binarySearchTree.Remove(100);
            Assert.AreEqual(6, binarySearchTree.Count);
            Assert.AreEqual(115, binarySearchTree.Head.Value);
            Assert.AreEqual(75, binarySearchTree.Head.LeftChild.Value); ;
            Assert.AreEqual(125, binarySearchTree.Head.RightChild.Value); ;
            Assert.IsNull(binarySearchTree.Head.RightChild.LeftChild);
        }


        [TestMethod]
        [TestCategory("Node to remove has a right child which has a left child")]
        public void InitialiseNewTree_With_Eight_Nodes_Remove_Node_Left_Of_Head()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);
            binarySearchTree.Add(75);
            binarySearchTree.Add(125);
            binarySearchTree.Add(50);
            binarySearchTree.Add(95);
            binarySearchTree.Add(90);
            binarySearchTree.Add(99);
            binarySearchTree.Add(80);


            binarySearchTree.Remove(75);
            Assert.AreEqual(7, binarySearchTree.Count);
            Assert.AreEqual(100, binarySearchTree.Head.Value);
            Assert.AreEqual(80, binarySearchTree.Head.LeftChild.Value); ;
            Assert.AreEqual(125, binarySearchTree.Head.RightChild.Value); ;
            Assert.IsNull(binarySearchTree.Head.LeftChild.RightChild.LeftChild.LeftChild);
        }

        [TestMethod]
        [TestCategory("Node to remove has a right child which has a left child")]
        public void InitialiseNewTree_With_Seven_Nodes_Remove_Node_Right_Of_Head()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);
            binarySearchTree.Add(75);
            binarySearchTree.Add(125);
            binarySearchTree.Add(115);
            binarySearchTree.Add(135);
            binarySearchTree.Add(130);
            binarySearchTree.Add(140);

            binarySearchTree.Remove(125);
            Assert.AreEqual(6, binarySearchTree.Count);
            Assert.AreEqual(100, binarySearchTree.Head.Value);
            Assert.AreEqual(75, binarySearchTree.Head.LeftChild.Value); ;
            Assert.AreEqual(130, binarySearchTree.Head.RightChild.Value); ;
            Assert.IsNull(binarySearchTree.Head.RightChild.LeftChild.LeftChild);
        }

        [TestMethod]
        [TestCategory("Traverse")]
        public void TraversePreOrder()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);
            binarySearchTree.Add(50);
            binarySearchTree.Add(200);
            binarySearchTree.Add(25);
            binarySearchTree.Add(75);
            binarySearchTree.Add(175);
            binarySearchTree.Add(225);

            binarySearchTree.PreOrderTraversal(i => Console.WriteLine(i));
        }

        [TestMethod]
        [TestCategory("Traverse")]
        public void TraversePostOrder()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);
            binarySearchTree.Add(50);
            binarySearchTree.Add(200);
            binarySearchTree.Add(25);
            binarySearchTree.Add(75);
            binarySearchTree.Add(175);
            binarySearchTree.Add(225);

            binarySearchTree.PostOrderTraversal(i => Console.WriteLine(i));
        }

        [TestMethod]
        [TestCategory("Traverse")]
        public void TraverseInOrderTraversal()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);
            binarySearchTree.Add(50);
            binarySearchTree.Add(200);
            binarySearchTree.Add(25);
            binarySearchTree.Add(75);
            binarySearchTree.Add(175);
            binarySearchTree.Add(225);

            binarySearchTree.InOrderTraversal(i => Console.WriteLine(i));
        }

        [TestMethod]
        [TestCategory("Traverse")]
        public void BreadthFirstTraversal()
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(100);
            binarySearchTree.Add(50);
            binarySearchTree.Add(200);
            binarySearchTree.Add(25);
            binarySearchTree.Add(75);
            binarySearchTree.Add(175);
            binarySearchTree.Add(225);

            var collection = binarySearchTree.BreadthFirstSearch();
            Assert.AreEqual(100, collection[0]);
            Assert.AreEqual(50, collection[1]);
            Assert.AreEqual(200, collection[2]);
            Assert.AreEqual(25, collection[3]);
            Assert.AreEqual(75, collection[4]);
            Assert.AreEqual(175, collection[5]);
            Assert.AreEqual(225, collection[6]);
        }
    }
}
