using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.CustomHashtable;

namespace Algorithms.HashTableTests
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void AddOneKeyValue()
        {
            var customHashTable = new CustomHashTable<string, Person>();

            var person = new Person { Name = "Vaibhav", Age = 35 };
            customHashTable.Add(person.Name, person);

            Assert.IsTrue(customHashTable.Contains(person.Name));
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void AddSameKeyResultsInException()
        {
            var customHashTable = new CustomHashTable<string, Person>();

            var person = new Person { Name = "Vaibhav", Age = 35 };
            var personTwo = new Person { Name = "Vaibhav", Age = 33 };

            customHashTable.Add(person.Name, person);
            customHashTable.Add(person.Name, personTwo);
        }
    }
}
