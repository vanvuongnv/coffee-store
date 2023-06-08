using System;
using CoffeShop.WebUI.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeShop.WebUI.Server.Data.EntityTypeConfigurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");

            builder.HasKey(o => o.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder
                .Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(e => e.ImageUrl)
                .HasMaxLength(2048);

            builder.HasOne<Category>()
                .WithMany()
                .HasForeignKey(x => x.CategoryId);

            builder.HasMany<OrderDetail>()
                .WithOne()
                .HasForeignKey(x => x.ProductId);

            builder.HasData(
                new Product()
                {
                    Id = 1,
                    CategoryId = 1,
                    ProductName = "Vietnamese Coffee",
                    ImageUrl = "",
                    Price = 29,
                    UnitsInStock = 100
                },
                new Product()
                {
                    Id = 2,
                    CategoryId = 1,
                    ProductName = "Vietnamese White Coffee",
                    ImageUrl = "",
                    Price = 29,
                    UnitsInStock = 99
                },
                new Product()
                {
                    Id = 3,
                    CategoryId = 1,
                    ProductName = "Vietnamese Milk Coffee",
                    ImageUrl = "",
                    Price = 29,
                    UnitsInStock = 74
                },
                new Product()
                {
                    Id = 4,
                    CategoryId = 2,
                    ProductName = "Espresso",
                    ImageUrl = "",
                    Price = 35,
                    UnitsInStock = 47
                },
                new Product()
                {
                    Id = 5,
                    CategoryId = 2,
                    ProductName = "Condensed Milk Espresso",
                    ImageUrl = "",
                    Price = 35,
                    UnitsInStock = 51
                },
                new Product()
                {
                    Id = 6,
                    CategoryId = 2,
                    ProductName = "Americano",
                    ImageUrl = "",
                    Price = 39,
                    UnitsInStock = 63
                },
                new Product()
                {
                    Id = 7,
                    CategoryId = 2,
                    ProductName = "Cappuccino",
                    ImageUrl = "",
                    Price = 45,
                    UnitsInStock = 56
                },
                new Product()
                {
                    Id = 8,
                    CategoryId = 2,
                    ProductName = "Late",
                    ImageUrl = "",
                    Price = 45,
                    UnitsInStock = 77
                },
                new Product()
                {
                    Id = 9,
                    CategoryId = 2,
                    ProductName = "Mocha",
                    ImageUrl = "",
                    Price = 49,
                    UnitsInStock = 99
                },
                new Product()
                {
                    Id = 10,
                    CategoryId = 2,
                    ProductName = "Caramel Macchiato",
                    ImageUrl = "",
                    Price = 55,
                    UnitsInStock = 88
                },
                new Product()
                {
                    Id = 11,
                    CategoryId = 3,
                    ProductName = "Black Tea",
                    ImageUrl = "",
                    Price = 35,
                    UnitsInStock = 11
                },
                new Product()
                {
                    Id = 12,
                    CategoryId = 3,
                    ProductName = "Flavored Tea",
                    ImageUrl = "",
                    Price = 35,
                    UnitsInStock = 22
                },
                new Product()
                {
                    Id = 13,
                    CategoryId = 3,
                    ProductName = "Black Tea Macchiato",
                    ImageUrl = "",
                    Price = 38,
                    UnitsInStock = 66
                },
                new Product()
                {
                    Id = 14,
                    CategoryId = 3,
                    ProductName = "Raspberry Macchiato",
                    ImageUrl = "",
                    Price = 42,
                    UnitsInStock = 22
                },
                new Product()
                {
                    Id = 15,
                    CategoryId = 3,
                    ProductName = "Peach Tea Mania",
                    ImageUrl = "",
                    Price = 42,
                    UnitsInStock = 33
                },
                new Product()
                {
                    Id = 16,
                    CategoryId = 3,
                    ProductName = "Matcha Late",
                    ImageUrl = "",
                    Price = 55,
                    UnitsInStock = 55
                },
                new Product()
                {
                    Id = 17,
                    CategoryId = 3,
                    ProductName = "Match Ice Blended",
                    ImageUrl = "",
                    Price = 59,
                    UnitsInStock = 44
                });
        }
    }
}

