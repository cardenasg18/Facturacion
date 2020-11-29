using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturacion.Web.Migrations
{
    public partial class Sillas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChairID",
                table: "PurchaseOrder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Items",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.CreateTable(
                name: "Chairs",
                columns: table => new
                {
                    ChairID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChairName = table.Column<string>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chairs", x => x.ChairID);
                    table.ForeignKey(
                        name: "FK_Chairs_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_ChairID",
                table: "PurchaseOrder",
                column: "ChairID");

            migrationBuilder.CreateIndex(
                name: "IX_Chairs_StatusId",
                table: "Chairs",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_Chairs_ChairID",
                table: "PurchaseOrder",
                column: "ChairID",
                principalTable: "Chairs",
                principalColumn: "ChairID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_Chairs_ChairID",
                table: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "Chairs");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrder_ChairID",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "ChairID",
                table: "PurchaseOrder");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Items",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 80);
        }
    }
}
