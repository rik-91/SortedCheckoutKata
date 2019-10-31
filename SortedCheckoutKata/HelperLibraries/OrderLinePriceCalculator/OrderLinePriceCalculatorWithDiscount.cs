using SortedCheckoutKata.BusinessObjects;
using SortedCheckoutKata.Database.KataItemsDatabaseAccess;

namespace SortedCheckoutKata.HelperLibraries.OrderLinePriceCalculator
{
    internal class OrderLinePriceCalculatorWithDiscount : IOrderLinePriceCalculator
    {
        private IKataItemsDatabaseAccess _kataItemsDatabaseAccess = null;

        public OrderLinePriceCalculatorWithDiscount(IKataItemsDatabaseAccess kataItemsDatabaseAccess)
        {
            _kataItemsDatabaseAccess = kataItemsDatabaseAccess;
        }

        public decimal Calculate(Item item, int itemQty)
        {
            decimal totalPrice = 0;
            int tempQty = itemQty;
            int specialOfferQty = _kataItemsDatabaseAccess.GetItemSpecialOfferQty(item.Sku);

            while (itemQty > 0)
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
