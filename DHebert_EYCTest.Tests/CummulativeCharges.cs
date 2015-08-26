using DHebert_EYCTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DHebert_EYCTest.Tests
{
    [TestClass]
    public class CummulativeCharges
    {
        [TestMethod]
        public void Just_Over_5000()
        {
            int units = 5005;
            double expected = 0.03;

            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                    .Returns(new Product("Test Product", Category.Processed, 1.00, Country.UK));
            lineItem.Object.Units = units;

            var actual = lineItem.Object.CalculateAdditionalCharges();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Just_Over_5000_And_Fresh()
        {
            int units = 5005;
            double expected = 0.04;

            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                    .Returns(new Product("Test Product", Category.Fresh, 1.00, Country.UK));
            lineItem.Object.Units = units;

            var actual = lineItem.Object.CalculateAdditionalCharges();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Just_Over_5000_And_Outside_The_UK()
        {
            int units = 5005;
            double expected = 0.04;

            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                    .Returns(new Product("Test Product", Category.Processed, 1.00, Country.Spain));
            lineItem.Object.Units = units;

            var actual = lineItem.Object.CalculateAdditionalCharges();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Just_Over_5000_Fresh_And_Outside_The_UK()
        {
            int units = 5005;
            double expected = 0.05;

            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                    .Returns(new Product("Test Product", Category.Fresh, 1.00, Country.Ireland));
            lineItem.Object.Units = units;

            var actual = lineItem.Object.CalculateAdditionalCharges();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Just_Over_1000_Fresh_And_Outside_The_UK()
        {
            int units = 1001;
            double expected = 0.06;

            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                    .Returns(new Product("Test Product", Category.Fresh, 1.00, Country.Spain));
            lineItem.Object.Units = units;

            var actual = lineItem.Object.CalculateAdditionalCharges();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Under_1000_Fresh_And_Outside_The_UK()
        {
            int units = 999;
            double expected = 0.08;

            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                    .Returns(new Product("Test Product", Category.Fresh, 1.00, Country.Spain));
            lineItem.Object.Units = units;

            var actual = lineItem.Object.CalculateAdditionalCharges();

            Assert.AreEqual(expected, actual);
        }
    }
}