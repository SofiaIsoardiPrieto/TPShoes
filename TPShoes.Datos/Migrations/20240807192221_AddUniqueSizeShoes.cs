using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPShoes.Datos.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueSizeShoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SizeShoes_ShoeId",
                table: "SizeShoes");

            migrationBuilder.CreateIndex(
                name: "IX_SizeShoes_ShoeId_SizeId",
                table: "SizeShoes",
                columns: new[] { "ShoeId", "SizeId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SizeShoes_ShoeId_SizeId",
                table: "SizeShoes");

            migrationBuilder.CreateIndex(
                name: "IX_SizeShoes_ShoeId",
                table: "SizeShoes",
                column: "ShoeId");
        }
    }
}
