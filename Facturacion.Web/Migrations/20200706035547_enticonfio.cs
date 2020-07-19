using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturacion.Web.Migrations
{
    public partial class enticonfio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Items_ItemId",
                table: "OrderDetail");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "Order",
                newName: "ShippingId");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Order",
                newName: "OrderTime");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "OrderDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "Order",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Valueimp",
                table: "Order",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "comentario",
                table: "Order",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentId",
                table: "Order",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingId",
                table: "Order",
                column: "ShippingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Payments_PaymentId",
                table: "Order",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Shippings_ShippingId",
                table: "Order",
                column: "ShippingId",
                principalTable: "Shippings",
                principalColumn: "ShippingId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Items_ItemId",
                table: "OrderDetail",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Payments_PaymentId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Shippings_ShippingId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Items_ItemId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_Order_PaymentId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ShippingId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Valueimp",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "comentario",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "ShippingId",
                table: "Order",
                newName: "OrderStatus");

            migrationBuilder.RenameColumn(
                name: "OrderTime",
                table: "Order",
                newName: "OrderDate");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "OrderDetail",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Items_ItemId",
                table: "OrderDetail",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
