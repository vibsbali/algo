using System;
using Algorithms.PriorityQueue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.PriorityQueueTests
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void AddThreeItems()
        {
            var priorityQueue = new PriorityQ<Data>();

            priorityQueue.Enqueue(new Data(message: "Priority High", priority: 10));
            priorityQueue.Enqueue(new Data("Low Priority", priority: 0));
            priorityQueue.Enqueue(new Data("Priority Medium", priority: 5));

            priorityQueue.Enqueue(new Data(message: "Priority High", priority: 10));
            priorityQueue.Enqueue(new Data("Low Priority", priority: 0));
            priorityQueue.Enqueue(new Data("Priority Medium", priority: 5));

            var message = priorityQueue.Dequeue();
            Assert.AreEqual(10, message.Priority);

            message = priorityQueue.Dequeue();
            Assert.AreEqual(10, message.Priority);

            priorityQueue.Enqueue(new Data(message: "Priority High", priority: 10));
            message = priorityQueue.Dequeue();
            Assert.AreEqual(10, message.Priority);

        }
    }
}
