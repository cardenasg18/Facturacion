using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturacion.Web.Migrations
{
    public partial class coñazo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalValue",
                table: "OrderDetail",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalValue",
                table: "Order",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "Order");
        }
    }
}
