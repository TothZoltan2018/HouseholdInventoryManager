using Dapper;
using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Repository
{
    class ProdCategoryCommands
    {
        private string _connectionString;

        public ProdCategoryCommands(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<ProdCategoryModel> GetList()
        {
            List<ProdCategoryModel> prodCategories = new List<ProdCategoryModel>();
            var sqlSPC = "ProdCategory_GetList";//SPC = Stored Procedure name on the SQL server
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                prodCategories = connection.Query<ProdCategoryModel>(sqlSPC).ToList();
            }
            return prodCategories;
        }
    }
}
