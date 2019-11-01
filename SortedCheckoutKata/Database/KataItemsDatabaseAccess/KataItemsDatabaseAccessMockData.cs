using Dapper;
using System;
using System.Data;
using System.Data.SQLite;

namespace SortedCheckoutKata.Database.KataItemsDatabaseAccess
{
    /// <summary>
    /// Data Access class for the Kata Items Database (Mock Data).
    /// </summary>
    internal class KataItemsDatabaseAccessMockData : IKataItemsDatabaseAccess
    {
        private static string _databaseFilePath = $@"{AppDomain.CurrentDomain.BaseDirectory}\Database\SortedCheckoutKata.db";
        private string _connectionString = $@"Data Source={_databaseFilePath};Version=3";

        /// <summary>
        /// Checks if the item exists.
        /// </summary>
        /// <param name="sku">The SKU of the item to check.</param>
        /// <returns>True if the item exists; false if not.</returns>
        public bool CheckItemExists(string sku)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Sku", sku);

            return Convert.ToBoolean(GetSingleDatabaseValue(SQLQueries.CheckItemExists, parameters, "ItemExists"));
        }

        /// <summary>
        /// Calculates the Total Price for the number of items (not including any special offers).
        /// </summary>
        /// <param name="sku">The SKU of the item.</param>
        /// <param name="itemQty">The quantity of the item.</param>
        /// <returns>The Total Price for the number of items (not including any special offers).</returns>
        public decimal CalculateTotalPrice(string sku, int itemQty)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Sku", sku);
            parameters.Add("@ItemQty", itemQty);

            return Convert.ToDecimal(GetSingleDatabaseValue(SQLQueries.GetTotalPrice, parameters, "TotalPrice"));
        }

        /// <summary>
        /// Checks if the item is eligable for a discount.
        /// </summary>
        /// <param name="sku">The SKU of the item.</param>
        /// <returns>True if the item is eligable for a discount; false if not.</returns>
        public bool CheckItemEligableForDiscount(string sku)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Sku", sku);

            return Convert.ToBoolean(GetSingleDatabaseValue(SQLQueries.CheckItemEligableForDiscount, parameters, "ItemEligableForDiscount"));
        }

        /// <summary>
        /// Gets the quantity of the item required to for special offer prices.
        /// </summary>
        /// <param name="sku">The SKU of the item.</param>
        /// <returns>The quantity of the item required to for special offer prices.</returns>
        public int GetItemSpecialOfferQty(string sku)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Sku", sku);

            return Convert.ToInt32(GetSingleDatabaseValue(SQLQueries.GetSpecialOfferQty, parameters, "OfferQty"));
        }

        /// <summary>
        /// Gets the Special Offer Price for the item (assuming it has the correct item quantity to qualify for the special offer price)
        /// </summary>
        /// <param name="sku">The SKU of the item.</param>
        /// <returns>The Special Offer Price for the item.</returns>
        public decimal GetSpecialOfferPrice(string sku)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Sku", sku);

            return Convert.ToDecimal(GetSingleDatabaseValue(SQLQueries.GetSpecialOfferPrice, parameters, "OfferPrice"));
        }

        /// <summary>
        /// Gets the standard unit price of the item.
        /// </summary>
        /// <param name="sku">The SKU of the item.</param>
        /// <returns>The standard unit price of the item.</returns>
        public decimal GetUnitPrice(string sku)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Sku", sku);

            return Convert.ToDecimal(GetSingleDatabaseValue(SQLQueries.GetUnitPrice, parameters, "UnitPrice"));
        }

        /// <summary>
        /// Gets a single value from the database (if the database returns multiple rows this will return the last rows value).
        /// </summary>
        /// <param name="queryText">The query to execute.</param>
        /// <param name="parameters">The queries parameters.</param>
        /// <param name="databaseColumn">The database column to retrieve the data from.</param>
        /// <returns>A single value from the database.</returns>
        private object GetSingleDatabaseValue(string queryText, DynamicParameters parameters, string databaseColumn)
        {
            object readerResults = new object();

            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                using (IDataReader reader = connection.ExecuteReader(queryText, parameters))
                {
                    while (reader.Read())
                    {
                        readerResults = reader[databaseColumn];
                    }
                }
            }

            return readerResults;
        }
    }
}
