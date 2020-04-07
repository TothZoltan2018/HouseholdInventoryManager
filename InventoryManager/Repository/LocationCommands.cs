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
    class LocationCommands
    {
        private string _connectionString;

        public LocationCommands(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<LocationModel> GetList()
        {
            List<LocationModel> locations = new List<LocationModel>();
            var sqlSPC = "Locations_GetList";//SPC = Stored Procedure name on the SQL server
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                locations = connection.Query<LocationModel>(sqlSPC).ToList();
            }
            return locations;
        }
    }
}
