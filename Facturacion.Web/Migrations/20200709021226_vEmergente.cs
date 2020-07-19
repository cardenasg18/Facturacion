using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturacion.Web.Migrations
{
    public partial class vEmergente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Items_ItemId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "OrderDetail");

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
                principalColumn: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Items_ItemId",
                table: "OrderDetail");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "OrderDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "OrderDetail",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Items_ItemId",
                table: "OrderDetail",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
