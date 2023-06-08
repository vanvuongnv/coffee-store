using System;
using CoffeShop.WebUI.Server.Data.Entities;
using CoffeShop.WebUI.Server.Data.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop.WebUI.Server.Data
{
	public class StoreDbContext : DbContext
	{
		public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
		{
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<OrderState> OrderStates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new OrderDetailEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new OrderStateEntityTypeConfiguration());
        }
    }
}

