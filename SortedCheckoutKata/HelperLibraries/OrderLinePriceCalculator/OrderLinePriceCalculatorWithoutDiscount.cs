using SortedCheckoutKata.BusinessObjects;
using SortedCheckoutKata.Database.KataItemsDatabaseAccess;

namespace SortedCheckoutKata.HelperLibraries.OrderLinePriceCalculator
{
    internal class OrderLinePriceCalculatorWithoutDiscount : IOrderLinePriceCalculator
    {
        private IKataItemsDatabaseAccess _kataItemsDatabaseAccess = null;

        public OrderLinePriceCalculatorWithoutDiscount(IKataItemsDatabaseAccess kataItemsDatabaseAccess)
        {
            _kataItemsDatabaseAccess = kataItemsDatabaseAccess;
        }

        public decimal Calculate(Item item, int itemQty)
        {
            return _kataItemsDatabaseAccess.CalculateTotalPrice(item.Sku, itemQty);
        }
    }
}
