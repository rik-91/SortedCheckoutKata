namespace SortedCheckoutKata.Database.KataItemsDatabaseAccess
{
    internal interface IKataItemsDatabaseAccess
    {
        bool CheckItemExists(string sku);
        decimal CalculateTotalPrice(string sku, int itemQty);
        bool CheckItemEligableForDiscount(string sku);
        int GetItemSpecialOfferQty(string sku);
        decimal GetSpecialOfferPrice(string sku);
        decimal GetUnitPrice(string sku);
    }
}
