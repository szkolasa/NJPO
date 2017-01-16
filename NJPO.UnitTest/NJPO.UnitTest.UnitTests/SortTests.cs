using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace NJPO.UnitTest.UnitTests
{
    [TestClass]
    public class SortTests
    {
        private Sort.Sort _sortList;

        [TestInitialize]
        public void TestInit()
        {
            _sortList = new Sort.Sort();
        }

        [TestMethod]
        public void ShouldSortFasterThanMinute()
        {
            // Arrange
            DateTime start, end;
            TimeSpan difference;
            List<int> sortedList;

            // Act

            start = DateTime.Now;

            sortedList = _sortList.GetSortedList();

            end = DateTime.Now;
            difference = end.Subtract(start);

            // Assert
            Assert.AreEqual(difference.Hours, 0);
            Assert.AreEqual(difference.Minutes, 0);
        }

        [TestMethod]
        public void ShouldSortSlowerThanMinute()
        {
            // Arrange
            DateTime start, end;
            TimeSpan difference;
            List<int> sortedList;

            // Act

            start = DateTime.Now;

            for (int i = 0; i < 50; i++)
            {
                sortedList = _sortList.GetSortedList();
            }

            end = DateTime.Now;
            difference = end.Subtract(start);

            // Assert
            Assert.IsTrue(difference.TotalMinutes > 1);
        }
    }
}
