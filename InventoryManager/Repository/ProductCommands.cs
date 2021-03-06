﻿using Dapper;
using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Repository
{
    class ProductCommands
    {
        private string _connectionString;

        public ProductCommands(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<ProductModel> GetList()
        {
            List<ProductModel> inventory = new List<ProductModel>();
            var sqlSPC = "Inventory_GetList";//SPC = Stored Procedure name on the SQL server
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                inventory = connection.Query<ProductModel>(sqlSPC).ToList();
            }
            return inventory;
        }

        public void UpSertItem(ProductModel productModel)
        {
            var sqlSPC = "Inventory_Upsert_Item";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Execute(sqlSPC, new
                {
                    @ProductId = productModel.ProductId,
                    @ProductName = productModel.ProductName,
                    @Description = productModel.Description,
                    @ProdCategoryId = productModel.ProdCategoryId,
                    @LocationId = productModel.LocationId,
                    @GetInDate = productModel.GetInDate,
                    @BestBefore = productModel.BestBefore,
                    @Quantity = productModel.Quantity,
                    @UnitId = productModel.UnitId
                },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteItem(int productId)
        {
            var sqlSPC = "Inventory_Delete_Item";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Execute(sqlSPC, new
                { @ProductId = productId }
                    ,commandType: CommandType.StoredProcedure);
            }
        }

        internal void EmptyTable()
        {
            var sqlSPC = "Inventory_EmptyTable";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Execute(sqlSPC, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
