using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace StoreApp.DbModel
{
    public class CodeFirstContext : DbContext
    {
        public CodeFirstContext() : base("DbConnectionString")
        {
            Database.SetInitializer<CodeFirstContext>(new CodeFirstContextInitialiser());
            Database.Initialize(false);
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Storage> Storages { get; set; }
    }

    public class CodeFirstContextInitialiser : CreateDatabaseIfNotExists<CodeFirstContext>
    {
        protected override void Seed(CodeFirstContext context)
        {
            var categories = new List<DbModel.Category>
            {
                new DbModel.Category{CategoryId = 1, Name = "Assepted" },
                new DbModel.Category{CategoryId = 2, Name = "OnStore" },
                new DbModel.Category{CategoryId = 3, Name = "Sold" }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            var storages = new List<DbModel.Storage>
            {
                new DbModel.Storage
                {
                    StorageId = 1,
                    Name = "Moscow Storage",
                    Adress = "Tsvetnoy Blvd 2 Moscow 127051"
                },
                new DbModel.Storage
                {
                    StorageId = 2,
                    Name = "Nizhnevartovsk Storage",
                    Adress = "st. Lenina, 15P, Nizhnevartovsk, Khanty-Mansi Autonomous Area, 628600"
                },
                new DbModel.Storage
                {
                    StorageId = 3,
                    Name = "Kazan Storage",
                    Adress = "ave. Khusain Yamasheva, 46, Kazan, Rep. Tatarstan, 420124"
                }
            };

            context.Storages.AddRange(storages);
            context.SaveChanges();

            var items = new List<DbModel.Item>
            {
                new DbModel.Item
                {
                    Title = "ASUS VivoBook L203MA Laptop",
                    Price = 17884,
                    CategoryId = 1,
                    MovingToCategoryDate = DateTime.Now,
                    StorageId = 1
                },
                new DbModel.Item
                {
                    Title = "Lenovo IdeaPad 3 14 Laptop",
                    Price = 30600,
                    CategoryId = 1,
                    MovingToCategoryDate = DateTime.Now,
                    StorageId = 1
                },
                new DbModel.Item
                {
                    Title = "Acer Aspire 1 A115-31-C2Y3",
                    Price = 12920,
                    CategoryId = 2,
                    MovingToCategoryDate = DateTime.Now,
                    StorageId = 1
                },
                new DbModel.Item
                {
                    Title = "Acer Aspire 5 Slim Laptop",
                    Price = 16123,
                    CategoryId = 2,
                    MovingToCategoryDate = DateTime.Now,
                    StorageId = 1
                },
                new DbModel.Item
                {
                    Title = "ASUS VivoBook 15 Thin and Light Laptop",
                    Price = 27200,
                    CategoryId = 2,
                    MovingToCategoryDate = DateTime.Now,
                    StorageId = 1
                },
                new DbModel.Item
                {
                    Title = "ASUS ZenBook 15 Laptop",
                    Price = 81600,
                    CategoryId = 3,
                    MovingToCategoryDate = DateTime.Now,
                    StorageId = 1
                }
            };

            context.Items.AddRange(items);
            context.SaveChanges();
        }
    }
}
