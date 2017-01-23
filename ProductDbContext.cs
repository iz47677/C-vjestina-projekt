using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebShop
{
    public class ProductDbContext : DbContext
    {
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<PurchaseViewModel> Orders { get; set; }

        public ProductDbContext(string connectionString) : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ProductDbContext>(null);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().HasKey(c => c._category);
            modelBuilder.Entity<PurchaseViewModel>().HasKey(c => c.E_mail);
        }
    }
}
