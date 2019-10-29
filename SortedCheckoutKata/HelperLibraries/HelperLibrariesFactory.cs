using SortedCheckoutKata.HelperLibraries.OrderLinePriceCalculator;

namespace SortedCheckoutKata.HelperLibraries
{
    public static class HelperLibrariesFactory
    {
        internal static IOrderLinePriceCalculator GetOrderLinePriceCalculator()
        {
            return new OrderLinePriceCalculator.OrderLinePriceCalculator();
        }
    }
}
