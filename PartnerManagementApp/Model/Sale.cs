using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerManagementApp.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }

        public Partner Partner { get; set; } = null!;
    }
}

