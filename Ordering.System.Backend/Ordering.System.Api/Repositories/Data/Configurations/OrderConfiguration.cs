﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Repositories.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Code)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Quantity)
                .IsRequired();

            builder.Property(p => p.TotalValue)
                .IsRequired();

            builder.Property(p => p.RequestDate)
                .HasDefaultValueSql("NOW()")
                .IsRequired();

            builder.HasOne(p => p.Supplier)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.Id);
        }
    }
}
