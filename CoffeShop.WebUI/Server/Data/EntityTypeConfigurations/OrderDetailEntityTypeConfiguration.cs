using System;
using CoffeShop.WebUI.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeShop.WebUI.Server.Data.EntityTypeConfigurations
{
    public class OrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("order_details");

            builder.HasKey(o => o.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.HasOne<Order>()
                .WithMany()
                .HasForeignKey(x => x.OrderId);

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(x => x.ProductId);

            builder.HasData(
                new OrderDetail() { Id = 1, OrderId = 1, Discount = 0, ProductId = 1, Quantity = 5, UnitPrice = 40 },
                new OrderDetail() { Id = 2, OrderId = 1, Discount = 10, ProductId = 2, Quantity = 2, UnitPrice = 30 },
                new OrderDetail() { Id = 3, OrderId = 1, Discount = 0, ProductId = 3, Quantity = 3, UnitPrice = 25 },
                new OrderDetail() { Id = 4, OrderId = 2, Discount = 10, ProductId = 4, Quantity = 1, UnitPrice = 55 },
                new OrderDetail() { Id = 5, OrderId = 2, Discount = 0, ProductId = 5, Quantity = 2, UnitPrice = 35 },
                new OrderDetail() { Id = 6, OrderId = 2, Discount = 0, ProductId = 6, Quantity = 3, UnitPrice = 45 },
                new OrderDetail() { Id = 7, OrderId = 3, Discount = 0, ProductId = 7, Quantity = 4, UnitPrice = 50 },
                new OrderDetail() { Id = 8, OrderId = 3, Discount = 0, ProductId = 8, Quantity = 5, UnitPrice = 60 },
                new OrderDetail() { Id = 9, OrderId = 3, Discount = 20, ProductId = 9, Quantity = 6, UnitPrice = 90 });
        }
    }
}

