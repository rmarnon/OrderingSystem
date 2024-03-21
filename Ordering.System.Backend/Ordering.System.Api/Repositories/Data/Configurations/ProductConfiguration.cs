using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Repositories.Data.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Code)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Value)
                .IsRequired();

            builder.Property(p => p.RegistrationDate)
                .HasDefaultValueSql("NOW()")
                .IsRequired();
        }
    }
}
