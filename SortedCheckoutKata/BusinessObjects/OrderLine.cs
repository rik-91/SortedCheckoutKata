﻿namespace SortedCheckoutKata.BusinessObjects
{
    public class OrderLine
    {
        public Item Item { get; set; }
        public int Qty { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountPrice { get; set; }
    }
}
