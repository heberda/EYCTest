using DHebert_EYCTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DHebert_EYCTest.Tests
{
    [TestClass]
    public class FreshCharges
    {
        [TestMethod]
        public void When_The_Item_Is_Fresh()
        {
            double expected = 0.01;

            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                    .Returns(new Product("Test Product", Category.Fresh, 1.00, Country.UK));

            var actual = lineItem.Object.FreshCharge();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_The_Item_Is_Not_Fresh()
        {
            double expected = 0;

            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                    .Returns(new Product("Test Product", Category.Processed, 1.00, Country.Spain));

            var actual = lineItem.Object.FreshCharge();

            Assert.AreEqual(expected, actual);
        }
    }
}