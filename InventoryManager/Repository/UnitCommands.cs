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
    class UnitCommands
    {
        private string _connectionString;

        public UnitCommands(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<UnitModel> GetList()
        {
            List<UnitModel> units = new List<UnitModel>();
            var sqlSPC = "Unit_GetList";//SPC = Stored Procedure name on the SQL server
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                units = connection.Query<UnitModel>(sqlSPC).ToList();
            }
            return units;
        }
    }
}
