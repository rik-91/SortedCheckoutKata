using SortedCheckoutKata.Database;
using SortedCheckoutKata.Database.KataItemsDatabaseAccess;
using SortedCheckoutKata.Enums;
using SortedCheckoutKata.HelperLibraries.OrderLinePriceCalculator;
using System;

namespace SortedCheckoutKata.HelperLibraries
{
    /// <summary>
    /// Provides implementations of the HelperLibrary interfaces.
    /// </summary>
    public static class HelperLibrariesFactory
    {
        /// <summary>
        /// Returns an implementation of the IOrderLinePriceCalculator interface.
        /// </summary>
        /// <param name="priceCalculationType">The type of IOrderLinePriceCalculator to return (WithoutDiscount or WithDiscount)</param>
        /// <returns>An implementation of the IOrderLinePriceCalculator interface.</returns>
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
