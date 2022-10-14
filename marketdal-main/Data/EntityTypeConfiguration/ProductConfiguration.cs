using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");
            builder.HasKey(product => product.Id);
            builder.Property(product => product.ProductName).HasMaxLength(100);
            builder.HasOne(product => product.Category)
                .WithMany(category => category.Products);
            builder.HasMany(product => product.ReceiptDetails)
                .WithOne(detail => detail.Product);
        }
    }
}