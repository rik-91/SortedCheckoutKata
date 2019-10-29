using SortedCheckoutKata.BusinessObjects;

namespace SortedCheckoutKata.HelperLibraries.OrderLinePriceCalculator
{
    internal class OrderLinePriceCalculatorWithoutDiscount : IOrderLinePriceCalculator
    {
        public decimal Calculate(Item item, int itemQty)
        {
            return 0;
        }
    }
}
