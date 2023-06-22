﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.InventoryModels
{
    public class Purchase : BaseEntity
    {
        public long ProductId { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedTime { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime DeliveryTime { get; set; }
        public string Description { get; set; }
        public bool Confirmation { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime ConfirmationTime { get; set; }

        public virtual Product Product { get; set; }
        //[ForeignKey("UserId")]
        //public virtual ApplicationUser User { get; set; }
    }
}
