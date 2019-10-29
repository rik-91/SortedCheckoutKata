﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedCheckoutKata.BusinessObjects
{
    public class Item
    {
        public string Sku { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
}
