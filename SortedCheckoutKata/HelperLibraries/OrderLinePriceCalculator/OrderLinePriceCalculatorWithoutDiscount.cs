using SortedCheckoutKata.BusinessObjects;
using SortedCheckoutKata.Database.KataItemsDatabaseAccess;

namespace SortedCheckoutKata.HelperLibraries.OrderLinePriceCalculator
{
    /// <summary>
    /// Calculates the order lines price (not including any special offers).
    /// </summary>
    internal class OrderLinePriceCalculatorWithoutDiscount : IOrderLinePriceCalculator
    {
        private IKataItemsDatabaseAccess _kataItemsDatabaseAccess = null;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="kataItemsDatabaseAccess">An implementation of the IKataItemsDatabaseAccess interface; used to access the KataItems database.</param>
        public OrderLinePriceCalculatorWithoutDiscount(IKataItemsDatabaseAccess kataItemsDatabaseAccess)
        {
            _kataItemsDatabaseAccess = kataItemsDatabaseAccess;
        }

        /// <summary>
        /// Calculates the Price.
        /// </summary>
        /// <param name="item">The item to calculate the price for.</param>
        /// <param name="itemQty">The item quantity.</param>
        /// <returns>The calculated price.</returns>
        public decimal Calculate(Item item, int itemQty)
        {
            return _kataItemsDatabaseAccess.CalculateTotalPrice(item.Sku, itemQty);
        }
    }
}
