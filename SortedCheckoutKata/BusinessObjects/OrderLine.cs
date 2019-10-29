using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedCheckoutKata.BusinessObjects
{
    public class OrderLine
    {
        public Item Item { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
}
