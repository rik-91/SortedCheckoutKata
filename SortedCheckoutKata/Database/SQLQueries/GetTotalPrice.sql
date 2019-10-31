SELECT (UnitPrice * @ItemQty) AS TotalPrice
FROM Items
WHERE Sku = @Sku