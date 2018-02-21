using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.StackAndQueueTests
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void InsertFourItems_Assert_Count_Of_Four()
        {
            var queue = new Algorithms.StackAndQueue.Queue<int>();

            for (int i = 0; i < 4; i++)
            {
                queue.Enqueue(i);
            }

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(i, queue.Dequeue());
            }
        }

        [TestMethod]
        public void InsertFiveItems_Assert_Count_Of_Five()
        {
            var stack = new Algorithms.StackAndQueue.Queue<int>();

            for (int i = 0; i < 5; i++)
            {
                stack.Enqueue(i);
            }

            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(i, stack.Dequeue());
            }
        }

        [TestMethod]
        public void InsertItems_Remove_Items()
        {
            var queue = new Algorithms.StackAndQueue.Queue<int>();

            queue.Enqueue(1);

           Assert.AreEqual(1, queue.Peek());

            queue.Enqueue(2);
            Assert.AreEqual(1, queue.Peek());

            var item = queue.Dequeue();
            Assert.AreEqual(1, item);

            queue.Enqueue(3);
            Assert.AreEqual(2, queue.Peek());

            item = queue.Dequeue();
            Assert.AreEqual(2, item);

            queue.Enqueue(4);
            Assert.AreEqual(3, queue.Peek());

            queue.Enqueue(5);
            Assert.AreEqual(3, queue.Peek());

            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);
            Assert.AreEqual(3, queue.Peek());
            
        }
    }
}
