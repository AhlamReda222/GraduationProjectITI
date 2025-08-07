using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GraduationProjectITI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Electronic devices", "Electronics" },
                    { 2, "Home and kitchen appliances", "Home & Kitchen" },
                    { 3, "Books and educational materials", "Books" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImagePath", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Laptop", "/images/laptop.jpg", 1200m, 10 },
                    { 2, 1, "Tablet", "/images/tablet.jpg", 800m, 15 },
                    { 3, 2, "Coffee Maker", "/images/coffee_maker.jpg", 50m, 25 },
                    { 4, 3, "Book: C# Basics", "/images/book1.jpg", 30m, 100 },
                    { 5, 3, "Book: ASP.NET Core", "/images/book2.jpg", 35m, 80 },
                    { 6, 2, "Blender", "/images/blender.jpg", 100m, 20 },
                    { 7, 1, "Smartphone", "/images/phone.jpg", 400m, 12 },
                    { 8, 2, "Toaster", "/images/toaster.jpg", 60m, 18 },
                    { 9, 3, "Book: EF Core Guide", "/images/book3.jpg", 25m, 70 },
                    { 10, 3, "Book: LINQ in Action", "/images/book4.jpg", 20m, 60 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
