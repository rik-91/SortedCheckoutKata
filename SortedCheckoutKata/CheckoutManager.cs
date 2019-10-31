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
        private int _currentlyScannedItemQty = 0;

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

            _currentlyScannedItemQty = _order.GetItemsOrderLine(item).Qty;

            CalculateTotalPrice(item);
            CalculateDiscountPrice(item);

            _currentlyScannedItemQty = 0;
        }

        public decimal TotalOfferInclusive()
        {
            return _order.DiscountPrice;
        }

        private void CalculateTotalPrice(Item item)
        {
            _orderLinePriceCalculator = HelperLibrariesFactory.GetOrderLinePriceCalculator(Enums.PriceCalculationType.WithoutDiscount);

            decimal price = _orderLinePriceCalculator.Calculate(item, _currentlyScannedItemQty);

            _order.SetItemTotalPrice(item, price);
        }

        private void CalculateDiscountPrice(Item item)
        {
            _orderLinePriceCalculator = HelperLibrariesFactory.GetOrderLinePriceCalculator(Enums.PriceCalculationType.WithDiscount);

            decimal price = _orderLinePriceCalculator.Calculate(item, _currentlyScannedItemQty);

            _order.SetItemDiscountPrice(item, price);
        }
    }
}
