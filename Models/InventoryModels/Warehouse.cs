using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.InventoryModels
{
    public class Warehouse
    {
        public long WarehouseId { get; set; }
        [Required]
        public string WarehouseName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Branch")]
        public long BranchId { get; set; }
    }
}
