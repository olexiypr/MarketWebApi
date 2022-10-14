using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
    public class ReceiptDetailConfiguration : IEntityTypeConfiguration<ReceiptDetail>
    {
        public void Configure(EntityTypeBuilder<ReceiptDetail> builder)
        {
            builder.ToTable("receipt_details");
            builder.HasKey(detail => detail.Id);
            builder.HasOne(detail => detail.Product)
                .WithMany(product => product.ReceiptDetails);
            builder.HasOne(detail => detail.Receipt)
                .WithMany(receipt => receipt.ReceiptDetails);
        }
    }
}