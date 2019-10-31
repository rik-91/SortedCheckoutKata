using SortedCheckoutKata.Database.KataItemsDatabaseAccess;
using SortedCheckoutKata.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedCheckoutKata.Database
{
    public static class DatabaseFactory
    {
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
