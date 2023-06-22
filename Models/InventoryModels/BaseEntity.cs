using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.InventoryModels
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public string TanentId { get; set; } = null!;
    }
}

//Dashboards
//Sales > Sales Channel
//Sales > Customer
//Sales > Sales Order
//Sales > Invoice    -----
//Sales > Invoice Payment -----
//Purchase > Vendor
//Purchase > Purchase Order
//Purchase > Bill
//Purchase > Bill Payment
//Merchandise > Uom     ----
//Merchandise > Size    
//Merchandise > Colour
//Merchandise > Flavour
//Merchandise > Brand
//Merchandise > Category
//Merchandise > Product
//Inventory > Shipper   
//Inventory > Location
//Inventory > Warehouse
//Inventory > Sales Delivery
//Inventory > Sales Return
//Inventory > Purchase Receipt
//Inventory > Purchase Return
//Inventory > Positive Adjustment
//Inventory > Negative Adjustment
//Inventory > Transfer Order
//Inventory > Stock
//Inventory > Movement
//Settings > Company
//Settings > Currency
//Settings > Purchase Tax
//Settings > Sales Tax

