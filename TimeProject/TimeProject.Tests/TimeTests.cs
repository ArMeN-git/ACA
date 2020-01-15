using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeProject.Tests
{
    [TestClass]
    public class TimeTests : IDisposable
    {
        private Time systemUnderTest;

        public TimeTests()
        {
            this.systemUnderTest = new Time(3, 30);
        }

        public void Dispose()
        {
            Debug.WriteLine("Dispose is called");
        }

        [TestMethod]
        public void ConstructorSetsHours()
        {
            Assert.AreEqual(3, this.systemUnderTest.Hours);
        }

        [TestMethod]
        public void ConstructorSetsMinutes()
        {
            Assert.AreEqual(30, this.systemUnderTest.Minutes);
        }

        [TestMethod]
        public void ConstructorCalculatesMinutesSinceMidnight()
        {
            Assert.AreEqual(210, this.systemUnderTest.MinutesSinceMidnight);
        }

        [TestMethod]
        public void AddMinutesToCurrentTime()
        {
            this.systemUnderTest += 40;

            Assert.AreEqual(4, this.systemUnderTest.Hours);
            Assert.AreEqual(10, this.systemUnderTest.Minutes);
        }

        [TestMethod]
        public void SubtractMinutesFromCurrentTime()
        {
            this.systemUnderTest -= 50;

            Assert.AreEqual(2, this.systemUnderTest.Hours);
            Assert.AreEqual(40, this.systemUnderTest.Minutes);
        }
    }
}
