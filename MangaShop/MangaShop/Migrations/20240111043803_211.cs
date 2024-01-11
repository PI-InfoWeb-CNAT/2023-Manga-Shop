using Microsoft.EntityFrameworkCore.Migrations;

namespace MangaShop.Migrations
{
    public partial class _211 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCartItems",
                table: "UserCartItems");

            migrationBuilder.DropIndex(
                name: "IX_UserCartItems_UserId",
                table: "UserCartItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCartItems",
                table: "UserCartItems",
                columns: new[] { "UserId", "ProductId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCartItems",
                table: "UserCartItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCartItems",
                table: "UserCartItems",
                column: "CartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCartItems_UserId",
                table: "UserCartItems",
                column: "UserId");
        }
    }
}
