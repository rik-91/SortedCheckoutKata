using SortedCheckoutKata.BusinessObjects;

namespace SortedCheckoutKata.HelperLibraries.OrderLinePriceCalculator
{
    internal interface IOrderLinePriceCalculator
    {
        decimal Calculate(Item item, int itemQty);
    }
}
