using SortedCheckoutKata.BusinessObjects;
using SortedCheckoutKata.Database.KataItemsDatabaseAccess;

namespace SortedCheckoutKata.HelperLibraries.OrderLinePriceCalculator
{
    /// <summary>
    /// Calculates the order lines price (including any special offers).
    /// </summary>
    internal class OrderLinePriceCalculatorWithDiscount : IOrderLinePriceCalculator
    {
        private IKataItemsDatabaseAccess _kataItemsDatabaseAccess = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="kataItemsDatabaseAccess">An implementation of the IKataItemsDatabaseAccess interface; used to access the KataItems database.</param>
        public OrderLinePriceCalculatorWithDiscount(IKataItemsDatabaseAccess kataItemsDatabaseAccess)
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
            decimal totalPrice = 0;
            int tempQty = itemQty;
            int specialOfferQty = _kataItemsDatabaseAccess.GetItemSpecialOfferQty(item.Sku);

            while (tempQty > 0)
            {
                if (tempQty >= specialOfferQty)
                {
                    totalPrice += _kataItemsDatabaseAccess.GetSpecialOfferPrice(item.Sku);
                    tempQty -= specialOfferQty;
                }
                else
                {
                    decimal unitPrice = _kataItemsDatabaseAccess.GetUnitPrice(item.Sku);

                    unitPrice *= tempQty;
                    totalPrice += unitPrice;
                    tempQty = 0;
                }
            }

            return totalPrice;
        }
    }
}
