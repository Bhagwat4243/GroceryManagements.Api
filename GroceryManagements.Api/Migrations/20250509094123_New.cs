using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroceryManagements.Api.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTbl_CategoryTbl_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryTbl",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTbl_CustomerTbl_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeelerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostPerQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockTbl_CategoryTbl_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryTbl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StockTbl_ItemTbl_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ItemTbl",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailsTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailsTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetailsTbl_CategoryTbl_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryTbl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetailsTbl_ItemTbl_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ItemTbl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetailsTbl_OrderTbl_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderTbl",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTbl_CategoryId",
                table: "ItemTbl",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailsTbl_CategoryId",
                table: "OrderDetailsTbl",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailsTbl_ItemId",
                table: "OrderDetailsTbl",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailsTbl_OrderId",
                table: "OrderDetailsTbl",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTbl_CustomerId",
                table: "OrderTbl",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTbl_CategoryId",
                table: "StockTbl",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTbl_ItemId",
                table: "StockTbl",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetailsTbl");

            migrationBuilder.DropTable(
                name: "StockTbl");

            migrationBuilder.DropTable(
                name: "OrderTbl");

            migrationBuilder.DropTable(
                name: "ItemTbl");

            migrationBuilder.DropTable(
                name: "CustomerTbl");

            migrationBuilder.DropTable(
                name: "CategoryTbl");
        }
    }
}
