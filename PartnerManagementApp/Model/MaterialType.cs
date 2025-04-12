using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerManagementApp.Models
{
    public class MaterialType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double DefectPercentage { get; set; }
    }
}

