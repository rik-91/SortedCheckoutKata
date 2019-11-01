using System.Collections.Generic;
using System.Linq;

namespace SortedCheckoutKata.BusinessObjects
{
    /// <summary>
    /// The order header. Holds all the orders' lines.
    /// </summary>
    internal class OrderHeader
    {
        /// <summary>
        /// The lines for the order.
        /// </summary>
        public List<OrderLine> OrderLines { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public OrderHeader()
        {
            OrderLines = new List<OrderLine>();
        }

        /// <summary>
        /// Gets the orders total price.
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;

                OrderLines.ForEach(line => totalPrice += line.TotalPrice);

                return totalPrice;
            }
        }

        /// <summary>
        /// Gets the orders discount price.
        /// </summary>
        public decimal DiscountPrice
        {
            get
            {
                decimal discountPrice = 0;

                OrderLines.ForEach(line => discountPrice += line.DiscountPrice);

                return discountPrice;
            }
        }

        /// <summary>
        /// Checks if the provided item exists in the Orders' lines.
        /// </summary>
        /// <param name="itemToCheck">The item to check.</param>
        /// <returns>True if the provided item exists in the Orders' lines; false if not.</returns>
        public bool CheckForItemInOrder(Item itemToCheck)
        {
            return OrderLines.Any(line => line.Item.Sku == itemToCheck.Sku);
        }

        /// <summary>
        /// Increments the quantity of the provided item's order line.
        /// </summary>
        /// <param name="itemToIncrement">The item to increment the quantity of.</param>
        public void IncrementItemQty(Item itemToIncrement)
        {
            OrderLines.FirstOrDefault(line => line.Item.Sku == itemToIncrement.Sku).Qty++;
        }

        /// <summary>
        /// Gets the order line of the provided item.
        /// </summary>
        /// <param name="orderLinesItem">The item of the order line to get.</param>
        /// <returns>The order line of the provided item.</returns>
        public OrderLine GetItemsOrderLine (Item orderLinesItem)
        {
            return OrderLines.FirstOrDefault(line => line.Item.Sku == orderLinesItem.Sku);
        }

        /// <summary>
        /// Creates a new order line for the provided item in the order header.
        /// </summary>
        /// <param name="itemToAdd"></param>
        public void CreateOrderLineForItem(Item itemToAdd)
        {
            OrderLine orderLine = new OrderLine()
            {
                Item = itemToAdd,
                Qty = 1
            };

            OrderLines.Add(orderLine);
        }

        /// <summary>
        /// Sets the total price of the order line for the provided item.
        /// </summary>
        /// <param name="itemToSetPrice">The item to set the price for.</param>
        /// <param name="price">The total price to set.</param>
        public void SetItemTotalPrice(Item itemToSetPrice, decimal price)
        {
            GetItemsOrderLine(itemToSetPrice).TotalPrice = price;
        }

        /// <summary>
        /// Sets the discount price of the order line for the provided item.
        /// </summary>
        /// <param name="itemToSetPrice">The item to set the price for.</param>
        /// <param name="price">The discount price to set.</param>
        public void SetItemDiscountPrice(Item itemToSetPrice, decimal price)
        {
            GetItemsOrderLine(itemToSetPrice).DiscountPrice = price;
        }
    }
}
