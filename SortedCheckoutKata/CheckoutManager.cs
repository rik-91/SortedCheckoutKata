using SortedCheckoutKata.BusinessObjects;
using SortedCheckoutKata.Database;
using SortedCheckoutKata.Database.KataItemsDatabaseAccess;
using SortedCheckoutKata.HelperLibraries;
using SortedCheckoutKata.HelperLibraries.OrderLinePriceCalculator;
using System;
using System.Collections.Generic;

namespace SortedCheckoutKata
{
    /// <summary>
    /// The Checkout Manager handles Scanning in items for an order and provides the total and discount costs of the order.
    /// </summary>
    public class CheckoutManager
    {
        private OrderHeader _order = null;
        private IOrderLinePriceCalculator _orderLinePriceCalculator = null;
        private IKataItemsDatabaseAccess _kataItemsDatabaseAccess = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public CheckoutManager()
        {
            _order = new OrderHeader()
            {
                OrderLines = new List<OrderLine>()
            };

            _kataItemsDatabaseAccess = DatabaseFactory.GetKataItemsDatabaseAccess(Enums.KataItemsDatabaseAccessType.MockData);
        }

        /// <summary>
        /// Returns the total cost of the order (not including any special offers).
        /// </summary>
        /// <returns>The total cost of the order (not including any special offers).</returns>
        public decimal Total()
        {
            return _order.TotalPrice;
        }

        /// <summary>
        /// Scans in a new item for the order.
        /// </summary>
        /// <param name="item">The item to add to the order.</param>
        public void Scan(Item item)
        {
            if (_kataItemsDatabaseAccess.CheckItemExists(item.Sku))
            {
                if (_order.CheckForItemInOrder(item))
                {
                    _order.IncrementItemQty(item);
                }
                else
                {
                    _order.CreateOrderLineForItem(item);
                }

                int currentlyScannedItemQty = _order.GetItemsOrderLine(item).Qty;

                decimal totalPrice = CalculateTotalPrice(item, currentlyScannedItemQty);
                decimal discountPrice = 0m;

                if (_kataItemsDatabaseAccess.CheckItemEligableForDiscount(item.Sku))
                {
                    discountPrice = CalculateDiscountPrice(item, currentlyScannedItemQty);
                }
                else
                {
                    discountPrice = CalculateTotalPrice(item, currentlyScannedItemQty);
                }

                _order.SetItemTotalPrice(item, totalPrice);
                _order.SetItemDiscountPrice(item, discountPrice);
            }
            else
                throw new Exception("Item does not exist.");
        }

        /// <summary>
        /// Returns the total cost of the order (including any special offers).
        /// </summary>
        /// <returns>The total cost of the order (including any special offers).</returns>
        public decimal TotalOfferInclusive()
        {
            return _order.DiscountPrice;
        }

        /// <summary>
        /// Calculates the total price for the provided item in this order based on the items quantity (not including any special offers).
        /// </summary>
        /// <param name="item">The item to calculate the price for.</param>
        /// <param name="itemQty">The item quantity.</param>
        /// <returns>The total price for the provided item in this order based on the items quantity (not including any special offers).</returns>
        private decimal CalculateTotalPrice(Item item, int itemQty)
        {
            _orderLinePriceCalculator = HelperLibrariesFactory.GetOrderLinePriceCalculator(Enums.PriceCalculationType.WithoutDiscount);

            return _orderLinePriceCalculator.Calculate(item, itemQty);
        }

        /// <summary>
        /// Calculates the total price for the provided item in this order based on the items quantity (including any special offers).
        /// </summary>
        /// <param name="item">The item to calculate the price for.</param>
        /// <param name="itemQty">The item quantity.</param>
        /// <returns>The total price for the provided item in this order based on the items quantity (including any special offers).</returns>
        private decimal CalculateDiscountPrice(Item item, int itemQty)
        {
            _orderLinePriceCalculator = HelperLibrariesFactory.GetOrderLinePriceCalculator(Enums.PriceCalculationType.WithDiscount);

            return _orderLinePriceCalculator.Calculate(item, itemQty);
        }
    }
}
