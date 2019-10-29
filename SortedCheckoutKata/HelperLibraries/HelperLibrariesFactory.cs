using SortedCheckoutKata.Enums;
using SortedCheckoutKata.HelperLibraries.OrderLinePriceCalculator;
using System;

namespace SortedCheckoutKata.HelperLibraries
{
    public static class HelperLibrariesFactory
    {
        internal static IOrderLinePriceCalculator GetOrderLinePriceCalculator(PriceCalculationType priceCalculationType)
        {
            switch (priceCalculationType)
            {
                case PriceCalculationType.WithoutDiscount:
                    return new OrderLinePriceCalculatorWithoutDiscount();
                case PriceCalculationType.WithDiscount:
                    return new OrderLinePriceCalculatorWithDiscount();
                default:
                    throw new Exception("Invalid PriceCalculationType enum provided to SortedCheckoutKata.HelperLibraries.GetOrderLinePriceCalculator method.");
            }
        }
    }
}
