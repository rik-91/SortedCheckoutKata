using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedCheckoutKata.Database.KataItemsDatabaseAccess
{
    internal class KataItemsDatabaseAccess : IKataItemsDatabaseAccess
    {
        private string _connectionString = @"Data Source=.\SortedCheckoutKata.db;Version=3";

        public KataItemsDatabaseAccess()
        {
        }

        public decimal CalculateTotalPrice(string sku, int itemQty)
        {
            decimal totalPrice = 0;

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Sku", sku);
            parameters.Add("@ItemQty", itemQty);

            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                using (IDataReader reader = connection.ExecuteReader(SQLQueries.GetTotalPrice, new DynamicParameters()))
                {
                    while(reader.Read())
                    {
                        totalPrice = Convert.ToDecimal(reader["TotalPrice"]);
                    }
                }
            }

            return totalPrice;
        }

        public decimal CalculateDiscountPrice(string sku, int itemQty)
        {
            return 0;
        }
    }
}
