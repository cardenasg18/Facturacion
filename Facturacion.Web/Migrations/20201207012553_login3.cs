using Microsoft.EntityFrameworkCore.Migrations;

namespace Facturacion.Web.Migrations
{
    public partial class login3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserMail",
                table: "Login");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Login",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Login_UserId",
                table: "Login",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Login_Usuarios_UserId",
                table: "Login",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Login_Usuarios_UserId",
                table: "Login");

            migrationBuilder.DropIndex(
                name: "IX_Login_UserId",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Login");

            migrationBuilder.AddColumn<string>(
                name: "UserMail",
                table: "Login",
                nullable: false,
                defaultValue: "");
        }
    }
}
