using Microsoft.EntityFrameworkCore.Migrations;

namespace MangaShop.Migrations
{
    public partial class testecarrinho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_carrinhos_CarrinhoId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "carrinhos");

            migrationBuilder.RenameColumn(
                name: "CarrinhoId",
                table: "Products",
                newName: "UserModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CarrinhoId",
                table: "Products",
                newName: "IX_Products_UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserModelId",
                table: "Products",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserModelId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UserModelId",
                table: "Products",
                newName: "CarrinhoId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserModelId",
                table: "Products",
                newName: "IX_Products_CarrinhoId");

            migrationBuilder.CreateTable(
                name: "carrinhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carrinhos", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_carrinhos_CarrinhoId",
                table: "Products",
                column: "CarrinhoId",
                principalTable: "carrinhos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
