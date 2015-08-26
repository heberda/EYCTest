using System;
using DHebert_EYCTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DHebert_EYCTest.Tests
{
    [TestClass]
    public class BulkCharges
    {
        [TestMethod]
        public void When_There_Is_Less_Than_1000()
        {
            double expected = 0.06;

            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                    .Returns(new Product("Test Product", Category.Fresh, 1.00, Country.UK));
            lineItem.Object.Units = 500;

            var actual = lineItem.Object.BulkCharge();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_There_Is_0()
        {
            double expected = 0;

            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                    .Returns(new Product("Test Product", Category.Fresh, 1.00, Country.UK));
            lineItem.Object.Units = 0;

            var actual = lineItem.Object.BulkCharge();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_There_Is_1()
        {
            double expected = 0.06;

            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                    .Returns(new Product("Test Product", Category.Fresh, 1.00, Country.UK));
            lineItem.Object.Units = 1;

            var actual = lineItem.Object.BulkCharge();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_There_Is_1000()
        {
            double expected = 0.06;

            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                    .Returns(new Product("Test Product", Category.Fresh, 1.00, Country.UK));
            lineItem.Object.Units = 1000;

            var actual = lineItem.Object.BulkCharge();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_There_Is_Over_1000()
        {
            double expected = 0.04;

            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                    .Returns(new Product("Test Product", Category.Fresh, 1.00, Country.UK));
            lineItem.Object.Units = 1005;

            var actual = lineItem.Object.BulkCharge();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_There_Is_Under_5000()
        {
            double expected = 0.04;

            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                    .Returns(new Product("Test Product", Category.Fresh, 1.00, Country.UK));
            lineItem.Object.Units = 4999;

            var actual = lineItem.Object.BulkCharge();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_There_Is_5000()
        {
            double expected = 0.04;

            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                    .Returns(new Product("Test Product", Category.Fresh, 1.00, Country.UK));
            lineItem.Object.Units = 5000;

            var actual = lineItem.Object.BulkCharge();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_There_Is_Over_5000()
        {
            double expected = 0.03;

            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                    .Returns(new Product("Test Product", Category.Fresh, 1.00, Country.UK));
            lineItem.Object.Units = 5001;

            var actual = lineItem.Object.BulkCharge();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_Units_Is_Max_Int()
        {
            double expected = 0.03;

            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                    .Returns(new Product("Test Product", Category.Fresh, 1.00, Country.UK));
            lineItem.Object.Units = Int32.MaxValue;

            var actual = lineItem.Object.BulkCharge();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_Units_Is_Negative()
        {
            double expected = 0;

            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                    .Returns(new Product("Test Product", Category.Fresh, 1.00, Country.UK));
            lineItem.Object.Units = -5;

            var actual = lineItem.Object.BulkCharge();

            Assert.AreEqual(expected, actual);
        }
    }
}