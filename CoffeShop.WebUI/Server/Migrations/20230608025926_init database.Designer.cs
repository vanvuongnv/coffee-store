﻿// <auto-generated />
using System;
using CoffeShop.WebUI.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoffeShop.WebUI.Server.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20230608025926_init database")]
    partial class initdatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CoffeShop.WebUI.Server.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Coffee"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Espresso"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Special tea"
                        });
                });

            modelBuilder.Entity("CoffeShop.WebUI.Server.Data.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("customers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerName = "Oliver"
                        },
                        new
                        {
                            Id = 2,
                            CustomerName = "Jack"
                        },
                        new
                        {
                            Id = 3,
                            CustomerName = "Harry"
                        });
                });

            modelBuilder.Entity("CoffeShop.WebUI.Server.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OrderNote")
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<int>("OrderStateId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderStateId");

                    b.ToTable("orders", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            OrderDate = new DateTimeOffset(new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            OrderStateId = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            OrderDate = new DateTimeOffset(new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            OrderStateId = 2
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3,
                            OrderDate = new DateTimeOffset(new DateTime(2023, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            OrderStateId = 3
                        });
                });

            modelBuilder.Entity("CoffeShop.WebUI.Server.Data.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Discount")
                        .HasColumnType("double precision");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("order_details", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Discount = 0.0,
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 5,
                            UnitPrice = 40.0
                        },
                        new
                        {
                            Id = 2,
                            Discount = 10.0,
                            OrderId = 1,
                            ProductId = 2,
                            Quantity = 2,
                            UnitPrice = 30.0
                        },
                        new
                        {
                            Id = 3,
                            Discount = 0.0,
                            OrderId = 1,
                            ProductId = 3,
                            Quantity = 3,
                            UnitPrice = 25.0
                        },
                        new
                        {
                            Id = 4,
                            Discount = 10.0,
                            OrderId = 2,
                            ProductId = 4,
                            Quantity = 1,
                            UnitPrice = 55.0
                        },
                        new
                        {
                            Id = 5,
                            Discount = 0.0,
                            OrderId = 2,
                            ProductId = 5,
                            Quantity = 2,
                            UnitPrice = 35.0
                        },
                        new
                        {
                            Id = 6,
                            Discount = 0.0,
                            OrderId = 2,
                            ProductId = 6,
                            Quantity = 3,
                            UnitPrice = 45.0
                        },
                        new
                        {
                            Id = 7,
                            Discount = 0.0,
                            OrderId = 3,
                            ProductId = 7,
                            Quantity = 4,
                            UnitPrice = 50.0
                        },
                        new
                        {
                            Id = 8,
                            Discount = 0.0,
                            OrderId = 3,
                            ProductId = 8,
                            Quantity = 5,
                            UnitPrice = 60.0
                        },
                        new
                        {
                            Id = 9,
                            Discount = 20.0,
                            OrderId = 3,
                            ProductId = 9,
                            Quantity = 6,
                            UnitPrice = 90.0
                        });
                });

            modelBuilder.Entity("CoffeShop.WebUI.Server.Data.Entities.OrderState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("order_states", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StateName = "Initial"
                        },
                        new
                        {
                            Id = 2,
                            StateName = "Processing"
                        },
                        new
                        {
                            Id = 3,
                            StateName = "Completed"
                        },
                        new
                        {
                            Id = 4,
                            StateName = "Cancel"
                        });
                });

            modelBuilder.Entity("CoffeShop.WebUI.Server.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            ImageUrl = "",
                            Price = 29.0,
                            ProductName = "Vietnamese Coffee",
                            UnitsInStock = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            ImageUrl = "",
                            Price = 29.0,
                            ProductName = "Vietnamese White Coffee",
                            UnitsInStock = 99
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            ImageUrl = "",
                            Price = 29.0,
                            ProductName = "Vietnamese Milk Coffee",
                            UnitsInStock = 74
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            ImageUrl = "",
                            Price = 35.0,
                            ProductName = "Espresso",
                            UnitsInStock = 47
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            ImageUrl = "",
                            Price = 35.0,
                            ProductName = "Condensed Milk Espresso",
                            UnitsInStock = 51
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            ImageUrl = "",
                            Price = 39.0,
                            ProductName = "Americano",
                            UnitsInStock = 63
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            ImageUrl = "",
                            Price = 45.0,
                            ProductName = "Cappuccino",
                            UnitsInStock = 56
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            ImageUrl = "",
                            Price = 45.0,
                            ProductName = "Late",
                            UnitsInStock = 77
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 2,
                            ImageUrl = "",
                            Price = 49.0,
                            ProductName = "Mocha",
                            UnitsInStock = 99
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            ImageUrl = "",
                            Price = 55.0,
                            ProductName = "Caramel Macchiato",
                            UnitsInStock = 88
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            ImageUrl = "",
                            Price = 35.0,
                            ProductName = "Black Tea",
                            UnitsInStock = 11
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 3,
                            ImageUrl = "",
                            Price = 35.0,
                            ProductName = "Flavored Tea",
                            UnitsInStock = 22
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 3,
                            ImageUrl = "",
                            Price = 38.0,
                            ProductName = "Black Tea Macchiato",
                            UnitsInStock = 66
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 3,
                            ImageUrl = "",
                            Price = 42.0,
                            ProductName = "Raspberry Macchiato",
                            UnitsInStock = 22
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 3,
                            ImageUrl = "",
                            Price = 42.0,
                            ProductName = "Peach Tea Mania",
                            UnitsInStock = 33
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 3,
                            ImageUrl = "",
                            Price = 55.0,
                            ProductName = "Matcha Late",
                            UnitsInStock = 55
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 3,
                            ImageUrl = "",
                            Price = 59.0,
                            ProductName = "Match Ice Blended",
                            UnitsInStock = 44
                        });
                });

            modelBuilder.Entity("CoffeShop.WebUI.Server.Data.Entities.Order", b =>
                {
                    b.HasOne("CoffeShop.WebUI.Server.Data.Entities.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffeShop.WebUI.Server.Data.Entities.OrderState", null)
                        .WithMany()
                        .HasForeignKey("OrderStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoffeShop.WebUI.Server.Data.Entities.OrderDetail", b =>
                {
                    b.HasOne("CoffeShop.WebUI.Server.Data.Entities.Order", null)
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffeShop.WebUI.Server.Data.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoffeShop.WebUI.Server.Data.Entities.Product", b =>
                {
                    b.HasOne("CoffeShop.WebUI.Server.Data.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}