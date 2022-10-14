using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.ToTable("receipts");
            builder.HasKey(receipt => receipt.Id);
            builder.HasOne(receipt => receipt.Customer)
                .WithMany(customer => customer.Receipts);
            builder.HasMany(receipt => receipt.ReceiptDetails)
                .WithOne(detail => detail.Receipt);
        }
    }
}