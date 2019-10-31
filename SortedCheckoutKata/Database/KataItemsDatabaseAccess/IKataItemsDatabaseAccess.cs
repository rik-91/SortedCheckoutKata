namespace SortedCheckoutKata.Database.KataItemsDatabaseAccess
{
    internal interface IKataItemsDatabaseAccess
    {
        decimal CalculateTotalPrice(string sku, int itemQty);
        decimal CalculateDiscountPrice(string sku, int itemQty);
    }
}
