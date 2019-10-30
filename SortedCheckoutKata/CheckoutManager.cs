using SortedCheckoutKata.BusinessObjects;
using SortedCheckoutKata.HelperLibraries;
using SortedCheckoutKata.HelperLibraries.OrderLinePriceCalculator;
using System.Collections.Generic;

namespace SortedCheckoutKata
{
    public class CheckoutManager
    {
        private OrderHeader _order = null;
        private IOrderLinePriceCalculator _orderLinePriceCalculator = null;

        public CheckoutManager()
        {
            _order = new OrderHeader()
            {
                OrderLines = new List<OrderLine>()
            };
        }

        public decimal Total()
        {
            return _order.TotalPrice;
        }

        public void Scan(Item item)
        {

            if(_order.CheckForItemInOrder(item))
            {
                _order.IncrementItemQty(item);
            }
            else
            {
                _order.AddNewItemToOrder(item);
            }

            CalculateTotalPrice(item);
            CalculateDiscountPrice(item);
        }

        public decimal TotalOfferInclusive()
        {
            return _order.DiscountPrice;
        }

        private void CalculateTotalPrice(Item item)
        {
            _orderLinePriceCalculator = HelperLibrariesFactory.GetOrderLinePriceCalculator(Enums.PriceCalculationType.WithoutDiscount);

            _order.GetItemsOrderLine(item).TotalPrice = _orderLinePriceCalculator.Calculate(_order.GetItemsOrderLine(item).Item, _order.GetItemsOrderLine(item).Qty);
        }

        private void CalculateDiscountPrice(Item item)
        {
            _orderLinePriceCalculator = HelperLibrariesFactory.GetOrderLinePriceCalculator(Enums.PriceCalculationType.WithDiscount);

            _order.GetItemsOrderLine(item).DiscountPrice = _orderLinePriceCalculator.Calculate(_order.GetItemsOrderLine(item).Item, _order.GetItemsOrderLine(item).Qty);
        }
    }
}
