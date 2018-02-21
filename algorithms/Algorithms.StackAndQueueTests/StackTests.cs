using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.StackAndQueueTests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void InsertFourItems_Assert_Count_Of_Four()
        {
            var stack = new Algorithms.StackAndQueue.Stack<int>();

            for (int i = 0; i < 4; i++)
            {
                stack.Push(i);
            }

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(3 - i, stack.Pop());
            }
        }

        [TestMethod]
        public void InsertFiveItems_Assert_Count_Of_Five()
        {
            var stack = new Algorithms.StackAndQueue.Stack<int>();

            for (int i = 0; i < 5; i++)
            {
                stack.Push(i);
            }

            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(4 - i, stack.Pop());
            }
        }

        [TestMethod]
        public void InsertOneItems_Assert_One_For_Peek()
        {
            var stack = new Algorithms.StackAndQueue.Stack<int>();

            stack.Push(1);

            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(1, stack.Peek());
            }
        }
    }
}
