using SortedCheckoutKata.BusinessObjects;

namespace SortedCheckoutKata.HelperLibraries.OrderLinePriceCalculator
{
    /// <summary>
    /// Calculates the order lines price.
    /// </summary>
    internal interface IOrderLinePriceCalculator
    {
        /// <summary>
        /// Calculates the Price.
        /// </summary>
        /// <param name="item">The item to calculate the price for.</param>
        /// <param name="itemQty">The item quantity.</param>
        /// <returns>The calculated price.</returns>
        decimal Calculate(Item item, int itemQty);
    }
}
