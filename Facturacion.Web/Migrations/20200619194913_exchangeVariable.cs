using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturacion.Web.Migrations
{
    public partial class exchangeVariable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Exchanges");

            migrationBuilder.AddColumn<decimal>(
                name: "ExchangeName",
                table: "Exchanges",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExchangeName",
                table: "Exchanges");

            migrationBuilder.AddColumn<float>(
                name: "Rate",
                table: "Exchanges",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
