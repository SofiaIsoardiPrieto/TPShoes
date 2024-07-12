using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TPShoes.Datos.Migrations
{
    /// <inheritdoc />
    public partial class AddShoeYShoeSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeNumber = table.Column<decimal>(type: "decimal(3,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "SizeShoes",
                columns: table => new
                {
                    SizeShoeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    Stok = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeShoes", x => x.SizeShoeId);
                    table.ForeignKey(
                        name: "FK_SizeShoes_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "ShoeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SizeShoes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "SizeNumber" },
                values: new object[,]
                {
                    { 1, 28m },
                    { 2, 28.5m },
                    { 3, 29.0m },
                    { 4, 29.5m },
                    { 5, 30.0m },
                    { 6, 30.5m },
                    { 7, 31.0m },
                    { 8, 31.5m },
                    { 9, 32.0m },
                    { 10, 32.5m },
                    { 11, 33.0m },
                    { 12, 33.5m },
                    { 13, 34.0m },
                    { 14, 34.5m },
                    { 15, 35.0m },
                    { 16, 35.5m },
                    { 17, 36.0m },
                    { 18, 36.5m },
                    { 19, 37.0m },
                    { 20, 37.5m },
                    { 21, 38.0m },
                    { 22, 38.5m },
                    { 23, 39.0m },
                    { 24, 39.5m },
                    { 25, 40.0m },
                    { 26, 40.5m },
                    { 27, 41.0m },
                    { 28, 41.5m },
                    { 29, 42.0m },
                    { 30, 42.5m },
                    { 31, 43.0m },
                    { 32, 43.5m },
                    { 33, 44.0m },
                    { 34, 44.5m },
                    { 35, 45.0m },
                    { 36, 45.5m },
                    { 37, 46.0m },
                    { 38, 46.5m },
                    { 39, 47.0m },
                    { 40, 47.5m },
                    { 41, 48.0m },
                    { 42, 48.5m },
                    { 43, 49.0m },
                    { 44, 49.5m },
                    { 45, 50.0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_SizeNumber",
                table: "Sizes",
                column: "SizeNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SizeShoes_ShoeId",
                table: "SizeShoes",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeShoes_SizeId",
                table: "SizeShoes",
                column: "SizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SizeShoes");

            migrationBuilder.DropTable(
                name: "Sizes");
        }
    }
}
