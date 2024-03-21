using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Repositories.Data.Configurations
{
    internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Cnpj)
                .HasColumnType("CHAR(14)")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.SocialReason)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Uf)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}