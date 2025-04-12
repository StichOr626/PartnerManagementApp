using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PartnerManagementApp.Models;

namespace PartnerManagementApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Partner> Partners => Set<Partner>();
        public DbSet<Sale> Sales => Set<Sale>();
        public DbSet<ProductType> ProductTypes => Set<ProductType>();
        public DbSet<MaterialType> MaterialTypes => Set<MaterialType>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=partners.db");
        }
    }
}

