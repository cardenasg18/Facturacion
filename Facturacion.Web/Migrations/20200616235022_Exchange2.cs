using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturacion.Web.Migrations
{
    public partial class Exchange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_Exchange_ExchangeId",
                table: "Currencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exchange",
                table: "Exchange");

            migrationBuilder.RenameTable(
                name: "Exchange",
                newName: "Exchanges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exchanges",
                table: "Exchanges",
                column: "ExchangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Exchanges_ExchangeId",
                table: "Currencies",
                column: "ExchangeId",
                principalTable: "Exchanges",
                principalColumn: "ExchangeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_Exchanges_ExchangeId",
                table: "Currencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exchanges",
                table: "Exchanges");

            migrationBuilder.RenameTable(
                name: "Exchanges",
                newName: "Exchange");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exchange",
                table: "Exchange",
                column: "ExchangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Exchange_ExchangeId",
                table: "Currencies",
                column: "ExchangeId",
                principalTable: "Exchange",
                principalColumn: "ExchangeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
