using SortedCheckoutKata.BusinessObjects;
using SortedCheckoutKata.Database;
using SortedCheckoutKata.Database.KataItemsDatabaseAccess;
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
        private IKataItemsDatabaseAccess _kataItemsDatabaseAccess = null;

        public CheckoutManager()
        {
            _order = new OrderHeader()
            {
                OrderLines = new List<OrderLine>()
            };

            _kataItemsDatabaseAccess = DatabaseFactory.GetKataItemsDatabaseAccess(Enums.KataItemsDatabaseAccessType.MockData);
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

            decimal totalPrice = CalculateTotalPrice(item);
            decimal discountPrice = 0m;

            if (_kataItemsDatabaseAccess.CheckItemEligableForDiscount(item.Sku))
            {
                discountPrice = CalculateDiscountPrice(item);
            }
            else
            {
                discountPrice = CalculateTotalPrice(item);
            }
            
            _order.SetItemTotalPrice(item, totalPrice);
            _order.SetItemDiscountPrice(item, discountPrice);

            _currentlyScannedItemQty = 0;
        }

        public decimal TotalOfferInclusive()
        {
            return _order.DiscountPrice;
        }

        private decimal CalculateTotalPrice(Item item)
        {
            _orderLinePriceCalculator = HelperLibrariesFactory.GetOrderLinePriceCalculator(Enums.PriceCalculationType.WithoutDiscount);

            return _orderLinePriceCalculator.Calculate(item, _currentlyScannedItemQty);
        }

        private decimal CalculateDiscountPrice(Item item)
        {
            _orderLinePriceCalculator = HelperLibrariesFactory.GetOrderLinePriceCalculator(Enums.PriceCalculationType.WithDiscount);

            return _orderLinePriceCalculator.Calculate(item, _currentlyScannedItemQty);
        }
    }
}
