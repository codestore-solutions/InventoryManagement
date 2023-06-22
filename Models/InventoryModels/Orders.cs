using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.InventoryModels
{
    public class Orders : BaseEntity
    {
        public long ProductId { get; set; }
        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public DateTime ConfirmDate { get; set; }
        public bool ConfirmStatus { get; set; }
        public string ShippingAddress { get; set; }
        public virtual Product Product { get; set; }
        //public virtual ApplicationUser User { get; set; }
    }
}
