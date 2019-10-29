using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedCheckoutKata.BusinessObjects
{
    public class OrderHeader
    {
        public List<OrderLine> OrderLines { get; set; }
    }
}
