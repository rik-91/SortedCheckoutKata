namespace SortedCheckoutKata.Database.KataItemsDatabaseAccess
{
    internal interface IKataItemsDatabaseAccess
    {
        decimal CalculateTotalPrice(string sku, int itemQty);
        int GetItemSpecialOfferQty(string sku);
        int GetSpecialOfferPrice(string sku);
    }
}
