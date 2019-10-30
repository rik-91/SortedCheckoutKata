using System.Collections.Generic;
using System.Linq;

namespace SortedCheckoutKata.BusinessObjects
{
    internal class OrderHeader
    {
        public List<OrderLine> OrderLines { get; set; }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;

                OrderLines.ForEach(line => totalPrice += line.TotalPrice);

                return totalPrice;
            }
        }

        public decimal DiscountPrice
        {
            get
            {
                decimal discountPrice = 0;

                OrderLines.ForEach(line => discountPrice += line.DiscountPrice);

                return discountPrice;
            }
        }

        public bool CheckForItemInOrder(Item itemToCheck)
        {
            return OrderLines.Any(line => line.Item.Sku == itemToCheck.Sku);
        }

        public void IncrementItemQty(Item itemToIncrement)
        {
            OrderLines.FirstOrDefault(line => line.Item.Sku == itemToIncrement.Sku).Qty++;
        }

        public OrderLine GetItemsOrderLine (Item orderLinesItem)
        {
            return OrderLines.FirstOrDefault(line => line.Item.Sku == orderLinesItem.Sku);
        }

        public void AddNewItemToOrder(Item itemToAdd)
        {
            OrderLine orderLine = new OrderLine()
            {
                Item = itemToAdd,
                Qty = 1
            };
        }
    }
}
