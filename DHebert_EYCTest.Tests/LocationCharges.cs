using System;
using DHebert_EYCTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DHebert_EYCTest.Tests
{
    [TestClass]
    public class LocationCharges
    {
        [TestMethod]
        public void When_In_UK()
        {
            double expected = 0;
            
            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                .Returns(new Product("Test Product", Category.Fresh, 1.00, Country.UK));

            double actual = lineItem.Object.LocationCharge();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void For_Non_UK()
        {
            double expected = 0.01;
            
            var lineItem = new Mock<LineItem>();
            lineItem.Setup(x => x.Product)
                .Returns(new Product("Test Product", Category.Fresh, 1.00, Country.Spain));

            double actual = lineItem.Object.LocationCharge();

            Assert.AreEqual(expected, actual);
        }
    }
}
