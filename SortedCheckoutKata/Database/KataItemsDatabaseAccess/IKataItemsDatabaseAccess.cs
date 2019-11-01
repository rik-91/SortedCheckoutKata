namespace SortedCheckoutKata.Database.KataItemsDatabaseAccess
{
    /// <summary>
    /// Data Access class for the Kata Items Database.
    /// </summary>
    internal interface IKataItemsDatabaseAccess
    {
        /// <summary>
        /// Checks if the item exists.
        /// </summary>
        /// <param name="sku">The SKU of the item to check.</param>
        /// <returns>True if the item exists; false if not.</returns>
        bool CheckItemExists(string sku);

        /// <summary>
        /// Calculates the Total Price for the number of items (not including any special offers).
        /// </summary>
        /// <param name="sku">The SKU of the item.</param>
        /// <param name="itemQty">The quantity of the item.</param>
        /// <returns>The Total Price for the number of items (not including any special offers).</returns>
        decimal CalculateTotalPrice(string sku, int itemQty);

        /// <summary>
        /// Checks if the item is eligable for a discount.
        /// </summary>
        /// <param name="sku">The SKU of the item.</param>
        /// <returns>True if the item is eligable for a discount; false if not.</returns>
        bool CheckItemEligableForDiscount(string sku);

        /// <summary>
        /// Gets the quantity of the item required to for special offer prices.
        /// </summary>
        /// <param name="sku">The SKU of the item.</param>
        /// <returns>The quantity of the item required to for special offer prices.</returns>
        int GetItemSpecialOfferQty(string sku);

        /// <summary>
        /// Gets the Special Offer Price for the item (assuming it has the correct item quantity to qualify for the special offer price)
        /// </summary>
        /// <param name="sku">The SKU of the item.</param>
        /// <returns>The Special Offer Price for the item.</returns>
        decimal GetSpecialOfferPrice(string sku);

        /// <summary>
        /// Gets the standard unit price of the item.
        /// </summary>
        /// <param name="sku">The SKU of the item.</param>
        /// <returns>The standard unit price of the item.</returns>
        decimal GetUnitPrice(string sku);
    }
}
