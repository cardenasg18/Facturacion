using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturacion.Web.Migrations
{
    public partial class TableXstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Suppliers",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Shippings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Sellers",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Items",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Employees",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Customers",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Companies",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Shippings_StatusId",
                table: "Shippings",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shippings_Statuses_StatusId",
                table: "Shippings",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shippings_Statuses_StatusId",
                table: "Shippings");

            migrationBuilder.DropIndex(
                name: "IX_Shippings_StatusId",
                table: "Shippings");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Shippings");

            migrationBuilder.AlterColumn<int>(
                name: "Telephone",
                table: "Suppliers",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Sellers",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Items",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Customers",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Companies",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
