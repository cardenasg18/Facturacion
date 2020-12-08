using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturacion.Web.Migrations
{
    public partial class comprasfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Items_ItemId",
                table: "OrderDetail");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "OrderDetail",
                newName: "ProductiD");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ItemId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ProductiD");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Products_ProductiD",
                table: "OrderDetail",
                column: "ProductiD",
                principalTable: "Products",
                principalColumn: "ProductiD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Products_ProductiD",
                table: "OrderDetail");

            migrationBuilder.RenameColumn(
                name: "ProductiD",
                table: "OrderDetail",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ProductiD",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Items_ItemId",
                table: "OrderDetail",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId");
        }
    }
}
