using SortedCheckoutKata.Database.KataItemsDatabaseAccess;
using SortedCheckoutKata.Enums;
using System;

namespace SortedCheckoutKata.Database
{
    /// <summary>
    /// Provides implementations of the Database interfaces.
    /// </summary>
    public static class DatabaseFactory
    {
        /// <summary>
        /// Returns an implementation of the IKataItemsDatabaseAccess interface.
        /// </summary>
        /// <param name="kataItemsDatabaseAccessType">The type of IKataItemsDatabaseAccess to return (MockData)</param>
        /// <returns>An implementation of the IKataItemsDatabaseAccess interface.</returns>
        internal static IKataItemsDatabaseAccess GetKataItemsDatabaseAccess(KataItemsDatabaseAccessType kataItemsDatabaseAccessType)
        {
            switch (kataItemsDatabaseAccessType)
            {
                case KataItemsDatabaseAccessType.MockData:
                    return new KataItemsDatabaseAccessMockData();
                default:
                    throw new Exception("Invalid KataItemsDatabaseAccessType enum provided to SortedCheckoutKata.Database.DatabaseFactory.GetKataItemsDatabaseAccess method.");
            }
        }
    }
}
