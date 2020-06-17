using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturacion.Web.Migrations
{
    public partial class exchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExchangeId",
                table: "Currencies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Exchange",
                columns: table => new
                {
                    ExchangeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rate = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchange", x => x.ExchangeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_ExchangeId",
                table: "Currencies",
                column: "ExchangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Exchange_ExchangeId",
                table: "Currencies",
                column: "ExchangeId",
                principalTable: "Exchange",
                principalColumn: "ExchangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_Exchange_ExchangeId",
                table: "Currencies");

            migrationBuilder.DropTable(
                name: "Exchange");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_ExchangeId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "ExchangeId",
                table: "Currencies");
        }
    }
}
