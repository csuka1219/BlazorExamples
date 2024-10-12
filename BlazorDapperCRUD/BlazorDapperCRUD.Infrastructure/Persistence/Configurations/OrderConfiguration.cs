﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BlazorDapperCRUD.Domain.Entities;

namespace BlazorDapperCRUD.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.OrderDate)
                .IsRequired();
            builder.Property(p => p.TotalAmount)
                .HasColumnType("decimal(18,2)");
        }
    }
}
