using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models
{
    class LocationModel
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int LocCategoryId { get; set; }
    }
}
