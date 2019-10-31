using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedCheckoutKata.Database.KataItemsDatabaseAccess
{
    internal class KataItemsDatabaseAccess : IKataItemsDatabaseAccess
    {
        public KataItemsDatabaseAccess()
        {
        }

        public decimal CalculateTotalPrice(string sku, int itemQty)
        {
            return 0;
        }

        public decimal CalculateDiscountPrice(string sku, int itemQty)
        {
            return 0;
        }
    }
}
