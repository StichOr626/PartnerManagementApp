using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerManagementApp.Models
{
    public class Partner
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string Address { get; set; } = string.Empty;
        public string DirectorName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<Sale> Sales { get; set; } = new();
        [NotMapped]
        public decimal Discount { get; set; }

    }

}
