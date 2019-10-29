using System.Collections.Generic;

namespace SortedCheckoutKata.BusinessObjects
{
    public class OrderHeader
    {
        public List<OrderLine> OrderLines { get; set; }
    }
}
