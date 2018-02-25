using System;
using Algorithms.BinarySearchTrees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.BinarySearchTreeWithParentsTests
{
    [TestClass]
    public class BinarySearchTreeWithParentWithParentTests
    {
        [TestMethod]
        public void InitialiseNewTree_Assert_Count_Zero()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            Assert.AreEqual(0, binarySearchTreeWithParent.Count);
            Assert.IsNotNull(binarySearchTreeWithParent);
        }

        [TestMethod]
        public void InitialiseNewTree_AddOneItem_Assert_Count_One()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            binarySearchTreeWithParent.Add(100);

            Assert.AreEqual(1, binarySearchTreeWithParent.Count);
            Assert.IsNotNull(binarySearchTreeWithParent);
            Assert.AreEqual(100, binarySearchTreeWithParent.Head.Value);
            Assert.IsTrue(binarySearchTreeWithParent.Contains(100));
        }


        [TestMethod]
        public void InitialiseNewTree_AddThreeItems_Of_DifferentValue__Assert_Count_Three_And_Check_Left_Right()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            binarySearchTreeWithParent.Add(100);
            binarySearchTreeWithParent.Add(75);
            binarySearchTreeWithParent.Add(125);

            Assert.AreEqual(3, binarySearchTreeWithParent.Count);
            Assert.IsNotNull(binarySearchTreeWithParent);
            Assert.AreEqual(100, binarySearchTreeWithParent.Head.Value);
            Assert.AreEqual(75, binarySearchTreeWithParent.Head.LeftChild.Value);
            Assert.AreEqual(125, binarySearchTreeWithParent.Head.RightChild.Value);

            Assert.IsTrue(binarySearchTreeWithParent.Contains(100));
            Assert.IsTrue(binarySearchTreeWithParent.Contains(75));
            Assert.IsTrue(binarySearchTreeWithParent.Contains(125));
        }

        [TestMethod]
        public void InitialiseNewTree_AddThreeItems_Of_SameValue_Assert_Count_Three_And_Check_Left_Right()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            binarySearchTreeWithParent.Add(100);
            binarySearchTreeWithParent.Add(75);
            binarySearchTreeWithParent.Add(100);

            Assert.AreEqual(3, binarySearchTreeWithParent.Count);
            Assert.IsNotNull(binarySearchTreeWithParent);
            Assert.AreEqual(100, binarySearchTreeWithParent.Head.Value);
            Assert.AreEqual(75, binarySearchTreeWithParent.Head.LeftChild.Value);
            Assert.AreEqual(100, binarySearchTreeWithParent.Head.RightChild.Value);

            Assert.IsTrue(binarySearchTreeWithParent.Contains(100));
            Assert.IsTrue(binarySearchTreeWithParent.Contains(75));
            Assert.IsTrue(binarySearchTreeWithParent.Contains(100));
        }

        [TestMethod]
        public void InitialiseNewTree_With_One_Node_Remove_Node_Assert_Count_Zero_Head_Null()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            binarySearchTreeWithParent.Add(100);

            binarySearchTreeWithParent.Remove(100);
            Assert.IsNull(binarySearchTreeWithParent.Head);
            Assert.AreEqual(0, binarySearchTreeWithParent.Count);
        }

        [TestMethod]
        public void InitialiseNewTree_With_Three_Nodes_Remove_Tail_Right_Of_Parent_Assert_Count_Of_Two()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            binarySearchTreeWithParent.Add(100);
            binarySearchTreeWithParent.Add(75);
            binarySearchTreeWithParent.Add(125);

            binarySearchTreeWithParent.Remove(125);
            Assert.AreEqual(2, binarySearchTreeWithParent.Count);
            Assert.IsNull(binarySearchTreeWithParent.Head.RightChild);
        }

        [TestMethod]
        public void InitialiseNewTree_With_Three_Nodes_Remove_Tail_Left_Of_Parent_Assert_Count_Of_Two()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            binarySearchTreeWithParent.Add(100);
            binarySearchTreeWithParent.Add(75);
            binarySearchTreeWithParent.Add(125);

            binarySearchTreeWithParent.Remove(75);
            Assert.AreEqual(2, binarySearchTreeWithParent.Count);
            Assert.IsNull(binarySearchTreeWithParent.Head.LeftChild);
        }

        [TestMethod]
        public void InitialiseNewTree_With_Two_Nodes_Remove_Head_Assert_Count_Of_One_And_New_Head()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            binarySearchTreeWithParent.Add(100);
            binarySearchTreeWithParent.Add(75);

            binarySearchTreeWithParent.Remove(100);
            Assert.AreEqual(1, binarySearchTreeWithParent.Count);

            Assert.AreEqual(75, binarySearchTreeWithParent.Head.Value);
            Assert.IsNull(binarySearchTreeWithParent.Head.RightChild);
            Assert.IsNull(binarySearchTreeWithParent.Head.LeftChild);
        }

        [TestMethod]
        public void InitialiseNewTree_With_Five_Nodes_Remove_Node_Left_Of_Parent_Which_Doesnt_Have_Right_Node_But_Has_left_node()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            binarySearchTreeWithParent.Add(100);
            binarySearchTreeWithParent.Add(75);
            binarySearchTreeWithParent.Add(125);
            binarySearchTreeWithParent.Add(50);
            binarySearchTreeWithParent.Add(115);

            binarySearchTreeWithParent.Remove(75);
            Assert.AreEqual(4, binarySearchTreeWithParent.Count);
            Assert.IsNotNull(binarySearchTreeWithParent.Head.LeftChild);
            Assert.AreEqual(50, binarySearchTreeWithParent.Head.LeftChild.Value);
        }

        [TestMethod]
        public void InitialiseNewTree_With_Five_Nodes_Remove_Node_Right_Of_Parent_Which_Doesnt_Have_Right_Node_But_Has_left_node()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            binarySearchTreeWithParent.Add(100);
            binarySearchTreeWithParent.Add(75);
            binarySearchTreeWithParent.Add(125);
            binarySearchTreeWithParent.Add(50);
            binarySearchTreeWithParent.Add(115);

            binarySearchTreeWithParent.Remove(125);
            Assert.AreEqual(4, binarySearchTreeWithParent.Count);
            Assert.IsNotNull(binarySearchTreeWithParent.Head.RightChild);
            Assert.AreEqual(115, binarySearchTreeWithParent.Head.RightChild.Value);
        }


        [TestMethod]
        [TestCategory("Node to remove has a right child which doesn't has a left child")]
        public void InitialiseNewTree_With_Five_Nodes_Remove_Head_Heads_RightChild_Has_No_Left_Child()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            binarySearchTreeWithParent.Add(100);
            binarySearchTreeWithParent.Add(75);
            binarySearchTreeWithParent.Add(125);
            binarySearchTreeWithParent.Add(50);
            binarySearchTreeWithParent.Add(135);

            binarySearchTreeWithParent.Remove(100);
            Assert.AreEqual(4, binarySearchTreeWithParent.Count);
            Assert.AreEqual(125, binarySearchTreeWithParent.Head.Value); ;
            Assert.AreEqual(135, binarySearchTreeWithParent.Head.RightChild.Value);
        }

        [TestMethod]
        [TestCategory("Node to remove has a right child which doesn't has a left child")]
        public void InitialiseNewTree_With_Seven_Nodes_Remove_Node_Left_Of_Parent_Whos_RightChild_Has_No_Left_Child()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            binarySearchTreeWithParent.Add(100);
            binarySearchTreeWithParent.Add(75);
            binarySearchTreeWithParent.Add(125);
            binarySearchTreeWithParent.Add(50);
            binarySearchTreeWithParent.Add(85);
            binarySearchTreeWithParent.Add(135);
            binarySearchTreeWithParent.Add(95);


            binarySearchTreeWithParent.Remove(75);
            Assert.AreEqual(6, binarySearchTreeWithParent.Count);
            Assert.AreEqual(85, binarySearchTreeWithParent.Head.LeftChild.Value); ;
            Assert.AreEqual(50, binarySearchTreeWithParent.Head.LeftChild.LeftChild.Value); ;
            Assert.AreEqual(95, binarySearchTreeWithParent.Head.LeftChild.RightChild.Value);
        }

        [TestMethod]
        [TestCategory("Node to remove has a right child which doesn't has a left child")]
        public void InitialiseNewTree_With_Seven_Nodes_Remove_Node_Right_Of_Parent_Whos_RightChild_Has_No_Left_Child()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            binarySearchTreeWithParent.Add(100);
            binarySearchTreeWithParent.Add(75);
            binarySearchTreeWithParent.Add(125);
            binarySearchTreeWithParent.Add(115);
            binarySearchTreeWithParent.Add(135);
            binarySearchTreeWithParent.Add(145);
            binarySearchTreeWithParent.Add(155);


            binarySearchTreeWithParent.Remove(125);
            Assert.AreEqual(6, binarySearchTreeWithParent.Count);
            Assert.AreEqual(135, binarySearchTreeWithParent.Head.RightChild.Value); ;
            Assert.AreEqual(115, binarySearchTreeWithParent.Head.RightChild.LeftChild.Value); ;
            Assert.AreEqual(145, binarySearchTreeWithParent.Head.RightChild.RightChild.Value);
        }


        [TestMethod]
        [TestCategory("Node to remove has a right child which has a left child")]
        public void InitialiseNewTree_With_Seven_Nodes_Remove_Head()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            binarySearchTreeWithParent.Add(100);
            binarySearchTreeWithParent.Add(75);
            binarySearchTreeWithParent.Add(125);
            binarySearchTreeWithParent.Add(115);
            binarySearchTreeWithParent.Add(135);
            binarySearchTreeWithParent.Add(145);
            binarySearchTreeWithParent.Add(155);


            binarySearchTreeWithParent.Remove(100);
            Assert.AreEqual(6, binarySearchTreeWithParent.Count);
            Assert.AreEqual(115, binarySearchTreeWithParent.Head.Value);
            Assert.AreEqual(75, binarySearchTreeWithParent.Head.LeftChild.Value); ;
            Assert.AreEqual(125, binarySearchTreeWithParent.Head.RightChild.Value); ;
            Assert.IsNull(binarySearchTreeWithParent.Head.RightChild.LeftChild);
        }


        [TestMethod]
        [TestCategory("Node to remove has a right child which has a left child")]
        public void InitialiseNewTree_With_Eight_Nodes_Remove_Node_Left_Of_Head()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            binarySearchTreeWithParent.Add(100);
            binarySearchTreeWithParent.Add(75);
            binarySearchTreeWithParent.Add(125);
            binarySearchTreeWithParent.Add(50);
            binarySearchTreeWithParent.Add(95);
            binarySearchTreeWithParent.Add(90);
            binarySearchTreeWithParent.Add(99);
            binarySearchTreeWithParent.Add(80);


            binarySearchTreeWithParent.Remove(75);
            Assert.AreEqual(7, binarySearchTreeWithParent.Count);
            Assert.AreEqual(100, binarySearchTreeWithParent.Head.Value);
            Assert.AreEqual(80, binarySearchTreeWithParent.Head.LeftChild.Value); ;
            Assert.AreEqual(125, binarySearchTreeWithParent.Head.RightChild.Value); ;
            Assert.IsNull(binarySearchTreeWithParent.Head.LeftChild.RightChild.LeftChild.LeftChild);
        }

        [TestMethod]
        [TestCategory("Node to remove has a right child which has a left child")]
        public void InitialiseNewTree_With_Seven_Nodes_Remove_Node_Right_Of_Head()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            binarySearchTreeWithParent.Add(100);
            binarySearchTreeWithParent.Add(75);
            binarySearchTreeWithParent.Add(125);
            binarySearchTreeWithParent.Add(115);
            binarySearchTreeWithParent.Add(135);
            binarySearchTreeWithParent.Add(130);
            binarySearchTreeWithParent.Add(140);

            binarySearchTreeWithParent.Remove(125);
            Assert.AreEqual(6, binarySearchTreeWithParent.Count);
            Assert.AreEqual(100, binarySearchTreeWithParent.Head.Value);
            Assert.AreEqual(75, binarySearchTreeWithParent.Head.LeftChild.Value); ;
            Assert.AreEqual(130, binarySearchTreeWithParent.Head.RightChild.Value); ;
            Assert.IsNull(binarySearchTreeWithParent.Head.RightChild.LeftChild.LeftChild);
        }

        [TestMethod]
        [TestCategory("Traverse")]
        public void TraversePreOrder()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            binarySearchTreeWithParent.Add(100);
            binarySearchTreeWithParent.Add(50);
            binarySearchTreeWithParent.Add(200);
            binarySearchTreeWithParent.Add(25);
            binarySearchTreeWithParent.Add(75);
            binarySearchTreeWithParent.Add(175);
            binarySearchTreeWithParent.Add(225);

            binarySearchTreeWithParent.PreOrderTraversal(i => Console.WriteLine(i));
        }

        [TestMethod]
        [TestCategory("Traverse")]
        public void TraversePostOrder()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            binarySearchTreeWithParent.Add(100);
            binarySearchTreeWithParent.Add(50);
            binarySearchTreeWithParent.Add(200);
            binarySearchTreeWithParent.Add(25);
            binarySearchTreeWithParent.Add(75);
            binarySearchTreeWithParent.Add(175);
            binarySearchTreeWithParent.Add(225);

            binarySearchTreeWithParent.PostOrderTraversal(i => Console.WriteLine(i));
        }

        [TestMethod]
        [TestCategory("Traverse")]
        public void TraverseInOrderTraversal()
        {
            var binarySearchTreeWithParent = new BinarySearchTreeWithParent<int>();
            binarySearchTreeWithParent.Add(100);
            binarySearchTreeWithParent.Add(50);
            binarySearchTreeWithParent.Add(200);
            binarySearchTreeWithParent.Add(25);
            binarySearchTreeWithParent.Add(75);
            binarySearchTreeWithParent.Add(175);
            binarySearchTreeWithParent.Add(225);

            binarySearchTreeWithParent.InOrderTraversal(i => Console.WriteLine(i));
        }
    }
}
