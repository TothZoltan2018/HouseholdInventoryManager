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
    class LocCategoryCommands
    {
        private string _connectionString;

        public LocCategoryCommands(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<LocationCategoryModel> GetList()
        {
            List<LocationCategoryModel> locationCategory = new List<LocationCategoryModel>();
            var sqlSPC = "LocCategory_GetList";//SPC = Stored Procedure name on the SQL server
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                locationCategory = connection.Query<LocationCategoryModel>(sqlSPC).ToList();
            }
            return locationCategory;
        }
    }
}
