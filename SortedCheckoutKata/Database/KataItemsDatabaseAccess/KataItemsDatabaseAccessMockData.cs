﻿using Dapper;
using System;
using System.Data;
using System.Data.SQLite;

namespace SortedCheckoutKata.Database.KataItemsDatabaseAccess
{
    internal class KataItemsDatabaseAccessMockData : IKataItemsDatabaseAccess
    {
        private static string _databaseFilePath = $@"{AppDomain.CurrentDomain.BaseDirectory}\Database\SortedCheckoutKata.db";
        private string _connectionString = $@"Data Source={_databaseFilePath};Version=3";

        public bool CheckItemExists(string sku)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Sku", sku);

            return Convert.ToBoolean(GetSingleDatabaseValue(SQLQueries.CheckItemExists, parameters, "ItemExists"));
        }

        public decimal CalculateTotalPrice(string sku, int itemQty)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Sku", sku);
            parameters.Add("@ItemQty", itemQty);

            return Convert.ToDecimal(GetSingleDatabaseValue(SQLQueries.GetTotalPrice, parameters, "TotalPrice"));
        }

        public bool CheckItemEligableForDiscount(string sku)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Sku", sku);

            return Convert.ToBoolean(GetSingleDatabaseValue(SQLQueries.CheckItemEligableForDiscount, parameters, "ItemEligableForDiscount"));
        }

        public int GetItemSpecialOfferQty(string sku)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Sku", sku);

            return Convert.ToInt32(GetSingleDatabaseValue(SQLQueries.GetSpecialOfferQty, parameters, "OfferQty"));
        }

        public decimal GetSpecialOfferPrice(string sku)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Sku", sku);

            return Convert.ToDecimal(GetSingleDatabaseValue(SQLQueries.GetSpecialOfferPrice, parameters, "OfferPrice"));
        }

        public decimal GetUnitPrice(string sku)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Sku", sku);

            return Convert.ToDecimal(GetSingleDatabaseValue(SQLQueries.GetUnitPrice, parameters, "UnitPrice"));
        }

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
