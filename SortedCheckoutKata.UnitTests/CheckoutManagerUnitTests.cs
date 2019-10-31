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
    }
}
