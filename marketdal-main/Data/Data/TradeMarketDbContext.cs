using System.IO;
using System.Threading.Tasks;
using Data.Entities;
using Data.EntityTypeConfiguration;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Data
{
    public class TradeMarketDbContext 
        : DbContext, ICustomerDbContext, IPersonDbContext, IProductCategoryDbContext, IProductDbContext, IReceiptDbContext, IReceiptDetailsDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptDetail> ReceiptDetails { get; set; }
        /*public TradeMarketDbContext(DbContextOptions<TradeMarketDbContext> options) : base(options)
        {
            
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration["DbConnection"];
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
