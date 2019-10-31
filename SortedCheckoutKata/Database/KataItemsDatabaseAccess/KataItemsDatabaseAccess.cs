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
            return 0;
        }

        public decimal CalculateDiscountPrice(string sku, int itemQty)
        {
            return 0;
        }
    }
}
