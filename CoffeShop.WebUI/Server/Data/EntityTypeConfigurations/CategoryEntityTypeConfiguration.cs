using System;
using CoffeShop.WebUI.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeShop.WebUI.Server.Data.EntityTypeConfigurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories");

            builder.HasKey(o => o.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder
                .Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany<Product>()
                .WithOne()
                .HasForeignKey(x => x.CategoryId);

            builder.HasData(new Category() { Id = 1, CategoryName = "Coffee" });
            builder.HasData(new Category() { Id = 2, CategoryName = "Espresso" });
            builder.HasData(new Category() { Id = 3, CategoryName = "Special tea" });
        }
    }
}

