using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models
{
    class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int ProdCategoryId { get; set; }
        public int LocationId { get; set; }        
        public DateTime GetInDate { get; set; }
        public DateTime BestBefore { get; set; }
        public float Quantity { get; set; }
        public int UnitId { get; set; }
    }
}
