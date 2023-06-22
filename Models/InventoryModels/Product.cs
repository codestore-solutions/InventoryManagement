using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.InventoryModels
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        [Column(TypeName = "Money")]
        public decimal SellingPrice { get; set; }
        [Column(TypeName = "Money")]
        public decimal PurchasingPrice { get; set; }
        public int Quantity { get; set; }
        public long CategoryId { get; set; }
        public long SupplierId { get; set; }


        public virtual Supplier Supplier { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }

    }
}
