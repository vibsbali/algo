using System;
using System.Threading;
using Algorithms.ArrayList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.ArrayListTests
{
    [TestClass]
    public class ArrayListTest
    {
        [TestMethod]
        [TestCategory("AddingElements")]
        public void InsertItem()
        {
            var arrayList = new ArrayList<int>();
            arrayList.Add(1);

            Assert.IsTrue(arrayList.Count == 1);
            Assert.IsTrue(arrayList.Contains(1));
        }

        [TestMethod]
        [TestCategory("AddingElements")]
        public void AddTwoItemsToBegining()
        {
            var arrayList = new ArrayList<int>();
            arrayList.Add(1);
            arrayList.Add(2);

            Assert.IsTrue(arrayList.Count == 2);
            Assert.IsTrue(arrayList.Contains(1));
            Assert.IsTrue(arrayList.Contains(2));
        }

        [TestMethod]
        [TestCategory("AddingElements")]
        public void AddingElementUsingIndexMethods()
        {
            var arrayList = new ArrayList<int>();
            arrayList.Insert(0, 1);
            arrayList.Insert(1, 2);
            arrayList[2] = 3;

            Assert.IsTrue(arrayList.Count == 3);
            Assert.IsTrue(arrayList.Contains(1));
            Assert.IsTrue(arrayList.IndexOf(1) == 0);
            Assert.IsTrue(arrayList.IndexOf(2) == 1);
            Assert.IsTrue(arrayList.IndexOf(3) == 2);
        }

        [TestMethod]
        [TestCategory("AddingElements")]
        public void AddingFiveElementsUsingIndexMethods()
        {
            var arrayList = new ArrayList<int>();
            arrayList.Insert(0, 1);
            arrayList.Insert(1, 2);
            arrayList[2] = 3;
            arrayList[3] = 4;
            arrayList[4] = 5;

            Assert.IsTrue(arrayList.Count == 5);
            Assert.IsTrue(arrayList.Contains(1));
            Assert.IsTrue(arrayList.IndexOf(1) == 0);
            Assert.IsTrue(arrayList.IndexOf(2) == 1);
            Assert.IsTrue(arrayList.IndexOf(3) == 2);
            Assert.IsTrue(arrayList.IndexOf(4) == 3);
            Assert.IsTrue(arrayList.IndexOf(5) == 4);
        }

        [TestMethod]
        [TestCategory("AddingElements")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddingElementsUsingIndexMethods_Throws_Exception()
        {
            var arrayList = new ArrayList<int>();
            arrayList.Insert(1, 1);
        }

        [TestMethod]
        [TestCategory("AddingElements")]
        public void AddingElementsAndTestingUsingIndexer()
        {
            var arrayList = new ArrayList<int>();
            arrayList[0] = 0;
            arrayList[1] = 1;

            Assert.IsTrue(arrayList.Count == 2);

            Assert.IsTrue(arrayList[0] == 0);
            Assert.IsTrue(arrayList[1] == 1);
        }

        [TestMethod]
        [TestCategory("RemovingElements")]
        public void RemoveAnElementFromTheList()
        {
            var arrayList = new ArrayList<int>();
            arrayList[0] = 0;
            arrayList[1] = 1;

            arrayList.Remove(1);

            Assert.IsTrue(arrayList.Count == 1);
            Assert.IsTrue(arrayList[0] == 0);
        }

        [TestMethod]
        [TestCategory("RemovingElements")]
        public void Add16ElementsRemove8()
        {
            var arrayList = new ArrayList<int>();
            for (int i = 0; i < 16; i++)
            {
                arrayList[i] = i;
            }

           
            Assert.IsTrue(arrayList.Count == 16);

            for (int i = 0; i < 12; i++)
            {
                arrayList.Remove(i);
            }

            Assert.IsTrue(arrayList.Count == 4);
            for (int i = 12,  j = 0; i < arrayList.Count; i++, j++)
            {
                Assert.IsTrue(i == arrayList[j]);
            }
        }

      
    }
}
