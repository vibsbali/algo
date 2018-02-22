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

        [TestMethod]
        public void AddOneKeyValueAndRetrieve()
        {
            var customHashTable = new CustomHashTable<string, Person>();

            var person = new Person { Name = "Vaibhav", Age = 35 };
            customHashTable.Add(person.Name, person);

            Assert.IsTrue(customHashTable.Contains(person.Name));

            var element = customHashTable.GetElement(person.Name);
            Assert.IsNotNull(element);

            Assert.AreEqual(person.Name, element.Name);
            Assert.AreEqual(person.Age, element.Age);
        }

        [TestMethod]
        public void AddTwoKeyValueAndRetrieveBoth()
        {
            var customHashTable = new CustomHashTable<string, Person>();

            var person = new Person { Name = "Vaibhav", Age = 35 };
            customHashTable.Add(person.Name, person);

            var personTwo = new Person { Name = "Vaibhav Bali", Age = 35 };
            customHashTable.Add(personTwo.Name, personTwo);

            Assert.IsTrue(customHashTable.Contains(person.Name));

            var element = customHashTable.GetElement(person.Name);
            Assert.IsNotNull(element);

            Assert.AreEqual(person.Name, element.Name);
            Assert.AreEqual(person.Age, element.Age);

            Assert.IsTrue(customHashTable.Contains(personTwo.Name));

            var secondElement = customHashTable.GetElement(personTwo.Name);
            Assert.IsNotNull(secondElement);

            Assert.AreEqual(personTwo.Name, secondElement.Name);
            Assert.AreEqual(personTwo.Age, secondElement.Age);
        }
    }
}
