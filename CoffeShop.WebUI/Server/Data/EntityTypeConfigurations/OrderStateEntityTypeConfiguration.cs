using System;
using CoffeShop.WebUI.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeShop.WebUI.Server.Data.EntityTypeConfigurations
{
    public class OrderStateEntityTypeConfiguration : IEntityTypeConfiguration<OrderState>
    {
        public void Configure(EntityTypeBuilder<OrderState> builder)
        {
            builder.ToTable("order_states");

            builder.HasKey(o => o.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.HasMany<Order>()
                .WithOne()
                .HasForeignKey(x => x.OrderStateId);

            builder.HasData(new OrderState() { Id = 1, StateName = "Initial" });
            builder.HasData(new OrderState() { Id = 2, StateName = "Processing" });
            builder.HasData(new OrderState() { Id = 3, StateName = "Completed" });
            builder.HasData(new OrderState() { Id = 4, StateName = "Cancel" });
        }
    }
}

