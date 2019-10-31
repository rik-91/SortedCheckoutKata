using SortedCheckoutKata.Database;
using SortedCheckoutKata.Database.KataItemsDatabaseAccess;
using SortedCheckoutKata.Enums;
using SortedCheckoutKata.HelperLibraries.OrderLinePriceCalculator;
using System;

namespace SortedCheckoutKata.HelperLibraries
{
    public static class HelperLibrariesFactory
    {
        internal static IOrderLinePriceCalculator GetOrderLinePriceCalculator(PriceCalculationType priceCalculationType)
        {
            IKataItemsDatabaseAccess kataItemsDatabaseAccess = DatabaseFactory.GetKataItemsDatabaseAccess(KataItemsDatabaseAccessType.MockData);

            switch (priceCalculationType)
            {
                case PriceCalculationType.WithoutDiscount:
                    return new OrderLinePriceCalculatorWithoutDiscount(kataItemsDatabaseAccess);
                case PriceCalculationType.WithDiscount:
                    return new OrderLinePriceCalculatorWithDiscount(kataItemsDatabaseAccess);
                default:
                    throw new Exception("Invalid PriceCalculationType enum provided to SortedCheckoutKata.HelperLibraries.HelperLibrariesFactory.GetOrderLinePriceCalculator method.");
            }
        }
    }
}
