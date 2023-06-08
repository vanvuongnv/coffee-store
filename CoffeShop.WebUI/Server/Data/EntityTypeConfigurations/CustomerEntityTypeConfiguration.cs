using System;
using CoffeShop.WebUI.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeShop.WebUI.Server.Data.EntityTypeConfigurations
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers");

            builder.HasKey(o => o.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder
                .Property(e => e.CustomerName)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(e => e.Address)
                .IsRequired(false)
                .HasMaxLength(255);

            builder
                .Property(e => e.Phone)
                .IsRequired(false)
                .HasMaxLength(255);

            builder
                .Property(e => e.Email)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.HasMany<Order>()
                .WithOne()
                .HasForeignKey(x => x.CustomerId);

            builder.HasData(new Customer() { Id = 1, CustomerName = "Oliver" });
            builder.HasData(new Customer() { Id = 2, CustomerName = "Jack" });
            builder.HasData(new Customer() { Id = 3, CustomerName = "Harry" });
        }
    }
}

