namespace SortedCheckoutKata.BusinessObjects
{
    /// <summary>
    /// The order line. Holds information about each item assigned to an order.
    /// </summary>
    internal class OrderLine
    {
        /// <summary>
        /// The item for the order.
        /// </summary>
        public Item Item { get; set; }
        /// <summary>
        /// The quantity of the item in the order.
        /// </summary>
        public int Qty { get; set; }
        /// <summary>
        /// The total price of the item in the order (not including any special offers).
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// The discount price of the item in the order (the total price but including any special offers).
        /// </summary>
        public decimal DiscountPrice { get; set; }
    }
}
