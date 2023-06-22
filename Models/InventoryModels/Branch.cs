using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.InventoryModels
{
    public class Branch
    {
        public long BranchId { get; set; }
        [Required]
        public string BranchName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Currency")]
        public int CurrencyId { get; set; }
        [Display(Name = "Street Address")]
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
    }
}
