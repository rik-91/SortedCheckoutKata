SELECT CASE WHEN COUNT(Sku) > 0 THEN 1 ELSE 0 END AS ItemEligableForDiscount
FROM SpecialOffers
WHERE Sku = @Sku