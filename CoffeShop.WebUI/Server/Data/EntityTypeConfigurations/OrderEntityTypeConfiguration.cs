using System;
using CoffeShop.WebUI.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeShop.WebUI.Server.Data.EntityTypeConfigurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");

            builder.HasKey(o => o.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder
                .Property(e => e.OrderNote)
                .IsRequired(false)
                .HasMaxLength(2048);

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(x => x.CustomerId);

            builder.HasOne<OrderState>()
                .WithMany()
                .HasForeignKey(x => x.OrderStateId);

            builder.HasMany<OrderDetail>()
                .WithOne()
                .HasForeignKey(x => x.OrderId);

            builder.HasData(new Order() { Id = 1, CustomerId = 1, OrderDate = new DateTime(2023, 04, 05, 0, 0, 0, DateTimeKind.Utc), OrderStateId = 1 });
            builder.HasData(new Order() { Id = 2, CustomerId = 2, OrderDate = new DateTime(2023, 04, 06, 0, 0, 0, DateTimeKind.Utc), OrderStateId = 2 });
            builder.HasData(new Order() { Id = 3, CustomerId = 3, OrderDate = new DateTime(2023, 04, 07, 0, 0, 0, DateTimeKind.Utc), OrderStateId = 3 });
        }
    }
}

