using Microsoft.EntityFrameworkCore.Migrations;

namespace MangaShop.Migrations
{
    public partial class carrinho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoCompraItens");

            migrationBuilder.AddColumn<int>(
                name: "CarrinhoId",
                table: "Products",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_CarrinhoId",
                table: "Products",
                column: "CarrinhoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_carrinhos_CarrinhoId",
                table: "Products",
                column: "CarrinhoId",
                principalTable: "carrinhos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_carrinhos_CarrinhoId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "carrinhos");

            migrationBuilder.DropIndex(
                name: "IX_Products_CarrinhoId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CarrinhoId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "CarrinhoCompraItens",
                columns: table => new
                {
                    CarrinhoCompraItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrinhoCompraId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoCompraItens", x => x.CarrinhoCompraItemId);
                    table.ForeignKey(
                        name: "FK_CarrinhoCompraItens_Products_ProductModelId",
                        column: x => x.ProductModelId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoCompraItens_ProductModelId",
                table: "CarrinhoCompraItens",
                column: "ProductModelId");
        }
    }
}
