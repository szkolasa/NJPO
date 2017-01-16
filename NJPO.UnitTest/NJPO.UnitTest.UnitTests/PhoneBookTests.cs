using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NJPO.Database;

namespace NJPO.UnitTest.UnitTests
{
    /// <summary>
    /// Code coverage:
    /// class Person: 100%
    /// class PhoneBook: 96,92%
    /// class DBConnector: 100%
    /// </summary>
    [TestClass]
    public class PhoneBookTests
    {
        private PhoneBook _phoneBook;

        /// <summary>
        /// Adds sample data
        /// </summary>
        [TestInitialize]
        public void TestInit()
        {
            _phoneBook = new PhoneBook();

            foreach (var item in GetSampleData())
            {
                _phoneBook.AddPerson(item);
            }
        }

        [TestMethod]
        public void ShouldAddNewPerson()
        {
            // Arrange
            var person = new Person
            {
                Name = "E",
                Surname = "E",
                Phone = "5"
            };

            // Act
            var result = _phoneBook.AddPerson(person);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(5, _phoneBook.GetBook().Count);
        }

        [TestMethod]
        public void ShouldDeletePerson()
        {
            // Arrange
            var person = _phoneBook.GetBook().Last();

            // Act
            var result = _phoneBook.DeletePerson(person.ID);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(3, _phoneBook.GetBook().Count);
        }

        [TestMethod]
        public void ShouldntDeletePerson()
        {
            // Arrange
            var id = _phoneBook.GetBook().Count + 1;

            // Act
            var result = _phoneBook.DeletePerson(id);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(4, _phoneBook.GetBook().Count);
        }

        [TestMethod]
        public void ShouldUpdatePerson()
        {
            // Arrange
            var person = _phoneBook.GetBook().Last();

            // Act
            person.Phone = "6";
            var result = _phoneBook.UpdatePerson(person);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual("6", _phoneBook.GetBook().Last().Phone);
        }

        /// <summary>
        /// Deletes all records from database
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            foreach (var person in _phoneBook.GetBook())
            {
                _phoneBook.DeletePerson(person.ID);
            }
        }

        private List<Person> GetSampleData()
        {
            return new List<Person>(new Person[]
            {
                new Person { Name = "A", Surname = "A", Phone = "1" },
                new Person { Name = "B", Surname = "B", Phone = "2" },
                new Person { Name = "C", Surname = "C", Phone = "3" },
                new Person { Name = "D", Surname = "D", Phone = "4" }
            });
        }
    }
}
