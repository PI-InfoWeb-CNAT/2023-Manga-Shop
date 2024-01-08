using Microsoft.EntityFrameworkCore.Migrations;

namespace MangaShop.Migrations
{
    public partial class carrinhcompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaDesejo");

            migrationBuilder.CreateTable(
                name: "CarrinhoCompraItens",
                columns: table => new
                {
                    CarrinhoCompraItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductModelId = table.Column<int>(type: "int", nullable: true),
                    CarrinhoCompraId = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoCompraItens");

            migrationBuilder.CreateTable(
                name: "ListaDesejo",
                columns: table => new
                {
                    ListaDesejoItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListaDesejoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaDesejo", x => x.ListaDesejoItemId);
                    table.ForeignKey(
                        name: "FK_ListaDesejo_Products_ProductModelId",
                        column: x => x.ProductModelId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListaDesejo_ProductModelId",
                table: "ListaDesejo",
                column: "ProductModelId");
        }
    }
}
