using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models
{
    class ProductModelAllTablesMerged : ProductModel
    {
        public string ProdCatName { get; set;}
        public string LocationName { get; set; }
        public string LocCatName { get; set; }
        public int LocCatId { get; set; }
        public string UnitName { get; set; }
 
        public SolidColorBrush ColorSet { get; set; }
    }
}
