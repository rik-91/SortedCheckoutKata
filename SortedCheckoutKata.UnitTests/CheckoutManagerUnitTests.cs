using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortedCheckoutKata.BusinessObjects;

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
    }
}
