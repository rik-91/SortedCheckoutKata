using Dapper;
using System;
using System.Data;
using System.Data.SQLite;

namespace SortedCheckoutKata.Database.KataItemsDatabaseAccess
{
    internal class KataItemsDatabaseAccessMockData : IKataItemsDatabaseAccess
    {
        private string _connectionString = @"Data Source=.\SortedCheckoutKata.db;Version=3";

        public decimal CalculateTotalPrice(string sku, int itemQty)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Sku", sku);
            parameters.Add("@ItemQty", itemQty);

            return Convert.ToDecimal(GetSingleDatabaseValue(SQLQueries.GetTotalPrice, parameters, "TotalPrice"));
        }

        public int GetItemSpecialOfferQty(string sku)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Sku", sku);

            return Convert.ToInt32(GetSingleDatabaseValue(SQLQueries.GetSpecialOfferQty, parameters, "OfferQty"));
        }

        public int GetSpecialOfferPrice(string sku)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Sku", sku);

            return Convert.ToInt32(GetSingleDatabaseValue(SQLQueries.GetTotalPrice, parameters, "OfferPrice"));
        }

        private object GetSingleDatabaseValue(string queryText, DynamicParameters parameters, string databaseColumn)
        {
            object readerResults = new object();

            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                using (IDataReader reader = connection.ExecuteReader(queryText, new DynamicParameters()))
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
