using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("persons");
            builder.HasKey(person => person.Id);
            builder.Property(person => person.Name).HasMaxLength(100);
            builder.Property(person => person.Surname).HasMaxLength(100);
        }
    }
}