using PartnerManagementApp.Models;
using System;
using System.Linq;

namespace PartnerManagementApp.Data
{
    public static class AutoSeeder
    {
        public static void Seed(AppDbContext db)
        {
            if (db.Partners.Any()) return;

            // Типы продукции
            var product1 = new ProductType { Name = "Тип 1", Coefficient = 1.2 };
            var product2 = new ProductType { Name = "Тип 2", Coefficient = 0.9 };
            db.ProductTypes.AddRange(product1, product2);

            // Типы материалов
            var material1 = new MaterialType { Name = "Материал A", DefectPercentage = 5.0 };
            var material2 = new MaterialType { Name = "Материал B", DefectPercentage = 2.5 };
            db.MaterialTypes.AddRange(material1, material2);

            db.SaveChanges();

            // Партнёры
            var p1 = new Partner
            {
                Name = "Компания Альфа",
                Type = "Оптовик",
                Rating = 5,
                Address = "Москва",
                DirectorName = "Иванов И.И.",
                Phone = "111-111",
                Email = "a@company.ru"
            };

            var p2 = new Partner
            {
                Name = "Компания Бета",
                Type = "Розничный",
                Rating = 3,
                Address = "Санкт-Петербург",
                DirectorName = "Петров П.П.",
                Phone = "222-222",
                Email = "b@company.ru"
            };

            var p3 = new Partner
            {
                Name = "Компания Гамма",
                Type = "Оптовик",
                Rating = 4,
                Address = "Екатеринбург",
                DirectorName = "Сидоров С.С.",
                Phone = "333-333",
                Email = "c@company.ru"
            };

            db.Partners.AddRange(p1, p2, p3);
            db.SaveChanges();

            // Продажи
            db.Sales.AddRange(
                new Sale { PartnerId = p1.Id, ProductName = "Продукт A", Quantity = 9000, SaleDate = DateTime.Today.AddDays(-10) },
                new Sale { PartnerId = p1.Id, ProductName = "Продукт B", Quantity = 2000, SaleDate = DateTime.Today.AddDays(-5) },
                new Sale { PartnerId = p2.Id, ProductName = "Продукт C", Quantity = 12000, SaleDate = DateTime.Today.AddDays(-7) },
                new Sale { PartnerId = p3.Id, ProductName = "Продукт D", Quantity = 40000, SaleDate = DateTime.Today.AddDays(-3) },
                new Sale { PartnerId = p3.Id, ProductName = "Продукт E", Quantity = 30000, SaleDate = DateTime.Today }
            );

            db.SaveChanges();
        }
    }
}

