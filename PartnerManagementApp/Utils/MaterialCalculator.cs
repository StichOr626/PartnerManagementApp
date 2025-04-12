using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartnerManagementApp.Data;

namespace PartnerManagementApp.Utils
{
    public static class MaterialCalculator
    {
        public static int CalculateRequiredMaterial(AppDbContext db, int productTypeId, int materialTypeId, int quantity, double param1, double param2)
        {
            var product = db.ProductTypes.Find(productTypeId);
            var material = db.MaterialTypes.Find(materialTypeId);

            if (product == null || material == null || quantity <= 0 || param1 <= 0 || param2 <= 0)
                return -1;

            double baseAmount = param1 * param2 * product.Coefficient;
            double defectiveFactor = 1 + material.DefectPercentage / 100.0;
            return (int)Math.Ceiling(baseAmount * defectiveFactor * quantity);
        }

        public static decimal CalculateDiscount(decimal totalSales)
        {
            if (totalSales < 10000) return 0;
            if (totalSales < 50000) return 0.05m;
            if (totalSales < 300000) return 0.10m;
            return 0.15m;
        }
    }
}

