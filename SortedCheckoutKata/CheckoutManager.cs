using SortedCheckoutKata.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedCheckoutKata
{
    public static class CheckoutManager
    {
        public static decimal Total()
        {
            return 0;
        }

        public static void Scan(string sku)
        {
            // 1. Check if item already exists in global list of Items'.
            // 1a. If yes increment the Items' qty
            // 1b. If no add a new Item to the global list and set its' qty to 1.

            // 2. Check if the qty of the item is a multiple of the special offer qty.
            // 2a. If yes just add the special qty price (0.30 for A99, 0.15 for B15) to the Items' Price.
            // 2b. If no just add the regular unit price to the Items' Price.
        }

        public static decimal TotalOfferInclusive()
        {
            return 0;
        }
    }
}
