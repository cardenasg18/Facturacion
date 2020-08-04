using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturacion.Web.Migrations
{
    public partial class OrdenCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    PaymentId = table.Column<int>(nullable: false),
                    ShippingId = table.Column<int>(nullable: false),
                    OrderTime = table.Column<DateTime>(nullable: false),
                    comentario = table.Column<string>(nullable: true),
                    SubTotal = table.Column<decimal>(nullable: false),
                    Valueimp = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalValue = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId");
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Shippings_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "Shippings",
                        principalColumn: "ShippingId");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetail",
                columns: table => new
                {
                    PurchaseDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<float>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    TotalValue = table.Column<decimal>(nullable: false),
                    PurchaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetail", x => x.PurchaseDetailId);
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_PurchaseOrder_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "PurchaseId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_ItemId",
                table: "PurchaseDetail",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_PurchaseId",
                table: "PurchaseDetail",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_CustomerId",
                table: "PurchaseOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_PaymentId",
                table: "PurchaseOrder",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_ShippingId",
                table: "PurchaseOrder",
                column: "ShippingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseDetail");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");
        }
    }
}
