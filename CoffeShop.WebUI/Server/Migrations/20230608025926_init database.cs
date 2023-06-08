using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeShop.WebUI.Server.Migrations
{
    /// <inheritdoc />
    public partial class initdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "order_states",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StateName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_states", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    UnitsInStock = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    OrderNote = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    OrderStateId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_order_states_OrderStateId",
                        column: x => x.OrderStateId,
                        principalTable: "order_states",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<double>(type: "double precision", nullable: false),
                    Discount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_details_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_details_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Coffee" },
                    { 2, "Espresso" },
                    { 3, "Special tea" }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "Id", "Address", "CustomerName", "Email", "Phone" },
                values: new object[,]
                {
                    { 1, null, "Oliver", null, null },
                    { 2, null, "Jack", null, null },
                    { 3, null, "Harry", null, null }
                });

            migrationBuilder.InsertData(
                table: "order_states",
                columns: new[] { "Id", "StateName" },
                values: new object[,]
                {
                    { 1, "Initial" },
                    { 2, "Processing" },
                    { 3, "Completed" },
                    { 4, "Cancel" }
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "OrderNote", "OrderStateId" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1 },
                    { 2, 2, new DateTimeOffset(new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 2 },
                    { 3, 3, new DateTimeOffset(new DateTime(2023, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 3 }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "Price", "ProductName", "UnitsInStock" },
                values: new object[,]
                {
                    { 1, 1, "", 29.0, "Vietnamese Coffee", 100 },
                    { 2, 1, "", 29.0, "Vietnamese White Coffee", 99 },
                    { 3, 1, "", 29.0, "Vietnamese Milk Coffee", 74 },
                    { 4, 2, "", 35.0, "Espresso", 47 },
                    { 5, 2, "", 35.0, "Condensed Milk Espresso", 51 },
                    { 6, 2, "", 39.0, "Americano", 63 },
                    { 7, 2, "", 45.0, "Cappuccino", 56 },
                    { 8, 2, "", 45.0, "Late", 77 },
                    { 9, 2, "", 49.0, "Mocha", 99 },
                    { 10, 2, "", 55.0, "Caramel Macchiato", 88 },
                    { 11, 3, "", 35.0, "Black Tea", 11 },
                    { 12, 3, "", 35.0, "Flavored Tea", 22 },
                    { 13, 3, "", 38.0, "Black Tea Macchiato", 66 },
                    { 14, 3, "", 42.0, "Raspberry Macchiato", 22 },
                    { 15, 3, "", 42.0, "Peach Tea Mania", 33 },
                    { 16, 3, "", 55.0, "Matcha Late", 55 },
                    { 17, 3, "", 59.0, "Match Ice Blended", 44 }
                });

            migrationBuilder.InsertData(
                table: "order_details",
                columns: new[] { "Id", "Discount", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 0.0, 1, 1, 5, 40.0 },
                    { 2, 10.0, 1, 2, 2, 30.0 },
                    { 3, 0.0, 1, 3, 3, 25.0 },
                    { 4, 10.0, 2, 4, 1, 55.0 },
                    { 5, 0.0, 2, 5, 2, 35.0 },
                    { 6, 0.0, 2, 6, 3, 45.0 },
                    { 7, 0.0, 3, 7, 4, 50.0 },
                    { 8, 0.0, 3, 8, 5, 60.0 },
                    { 9, 20.0, 3, 9, 6, 90.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_details_OrderId",
                table: "order_details",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_order_details_ProductId",
                table: "order_details",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerId",
                table: "orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_OrderStateId",
                table: "orders",
                column: "OrderStateId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_details");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "order_states");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
