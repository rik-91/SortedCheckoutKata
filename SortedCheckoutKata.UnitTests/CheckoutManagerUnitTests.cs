using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortedCheckoutKata.BusinessObjects;
using System;

namespace SortedCheckoutKata.UnitTests
{
    [TestClass]
    public class CheckoutManagerUnitTests
    {
        [TestMethod]
        public void GetTotalPrice_SingleApple_TotalPriceMatchExpectedPrice()
        {
            // Arrange
            decimal expectedPrice = 0.50m;
            CheckoutManager checkoutManager = new CheckoutManager();
            Item apple = new Item()
            {
                Sku = "A99"
            };

            // Act
            checkoutManager.Scan(apple);

            // Assert
            decimal price = checkoutManager.Total();
            Assert.AreEqual(price, expectedPrice);
        }

        [TestMethod]
        public void GetTotalPrice_ThreeApplesTwoBiscuits_TotalPriceMatchExpectedPrice()
        {
            // Arrange
            decimal expectedPrice = 2.10m;
            CheckoutManager checkoutManager = new CheckoutManager();
            Item apple = new Item()
            {
                Sku = "A99"
            };

            Item biscuit = new Item()
            {
                Sku = "B15"
            };

            // Act
            checkoutManager.Scan(apple);
            checkoutManager.Scan(biscuit);
            checkoutManager.Scan(apple);
            checkoutManager.Scan(biscuit);
            checkoutManager.Scan(apple);

            // Assert
            decimal price = checkoutManager.Total();
            Assert.AreEqual(price, expectedPrice);
        }

        [TestMethod]
        public void GetTotalPrice_ThreeApplesTwoBiscuits_DiscountPriceMatchExpectedPrice()
        {
            // Arrange
            decimal expectedPrice = 1.75m;
            CheckoutManager checkoutManager = new CheckoutManager();
            Item apple = new Item()
            {
                Sku = "A99"
            };

            Item biscuit = new Item()
            {
                Sku = "B15"
            };

            // Act
            checkoutManager.Scan(apple);
            checkoutManager.Scan(biscuit);
            checkoutManager.Scan(apple);
            checkoutManager.Scan(biscuit);
            checkoutManager.Scan(apple);

            // Assert
            decimal price = checkoutManager.TotalOfferInclusive();
            Assert.AreEqual(price, expectedPrice);
        }

        [TestMethod]
        public void GetTotalPrice_ThreeApplesTwoBiscuitsOneUnkownItem_TotalPriceMatchExpectedPrice()
        {
            // Arrange
            decimal expectedPrice = 2.70m;
            CheckoutManager checkoutManager = new CheckoutManager();
            Item apple = new Item()
            {
                Sku = "A99"
            };

            Item biscuit = new Item()
            {
                Sku = "B15"
            };

            Item unkownItem = new Item()
            {
                Sku = "C40"
            };

            // Act
            checkoutManager.Scan(apple);
            checkoutManager.Scan(biscuit);
            checkoutManager.Scan(apple);
            checkoutManager.Scan(biscuit);
            checkoutManager.Scan(unkownItem);
            checkoutManager.Scan(apple);

            // Assert
            decimal price = checkoutManager.Total();
            Assert.AreEqual(price, expectedPrice);
        }

        [TestMethod]
        public void GetTotalPrice_ThreeApplesTwoBiscuitsOneUnkownItem_DiscountPriceMatchExpectedPrice()
        {
            // Arrange
            decimal expectedPrice = 2.35m;
            CheckoutManager checkoutManager = new CheckoutManager();
            Item apple = new Item()
            {
                Sku = "A99"
            };

            Item biscuit = new Item()
            {
                Sku = "B15"
            };

            Item unkownItem = new Item()
            {
                Sku = "C40"
            };

            // Act
            checkoutManager.Scan(apple);
            checkoutManager.Scan(biscuit);
            checkoutManager.Scan(apple);
            checkoutManager.Scan(biscuit);
            checkoutManager.Scan(unkownItem);
            checkoutManager.Scan(apple);

            // Assert
            decimal price = checkoutManager.TotalOfferInclusive();
            Assert.AreEqual(price, expectedPrice);
        }

        [TestMethod]
        public void Scan_NonExistentItem_ThrowException()
        {
            // Arrange
            CheckoutManager checkoutManager = new CheckoutManager();
            Item nonExistentItem = new Item()
            {
                Sku = ""
            };

            // Assert
            Assert.ThrowsException<Exception>(() => checkoutManager.Scan(nonExistanItem));
        }
    }
}
