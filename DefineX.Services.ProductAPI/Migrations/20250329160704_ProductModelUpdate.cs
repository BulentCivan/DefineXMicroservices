using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DefineX.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class ProductModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    image_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    alt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    variant_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.image_id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Collection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHot = table.Column<bool>(type: "bit", nullable: false),
                    discount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    variant_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.variant_id);
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "image_id", "alt", "id", "src", "variant_id" },
                values: new object[,]
                {
                    { 111, "yellow", 1, "1.png", "[101]" },
                    { 112, "white", 1, "2.png", "[102]" },
                    { 211, "olive", 2, "3.png", "[201]" },
                    { 212, "navy", 2, "4.png", "[202]" },
                    { 311, "whredite", 3, "5.png", "[301]" },
                    { 312, "red", 3, "6.png", "[302]" },
                    { 411, "green", 4, "7.png", "[401]" },
                    { 412, "skyblue", 4, "8.png", "[403]" },
                    { 511, "green", 5, "9.png", "[501]" },
                    { 512, "black", 5, "10.png", "[502]" },
                    { 611, "olive", 6, "11.png", "[601]" },
                    { 612, "gray", 6, "12.png", "[602]" },
                    { 1211, "red", 12, "8.png", "[1201]" },
                    { 1212, "pink", 12, "9.png", "[1202]" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "Brand", "CategoryName", "Collection", "Description", "IsHot", "IsNew", "Price", "Title", "Type", "discount", "tags" },
                values: new object[,]
                {
                    { 1, "nike", "Women", "[\"YEN\\u0130 GELEN \\u00DCR\\u00DCNLER\"]", "Vivamus suscipit tortor eget felis porttitor volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin eget tortor risus. Nulla porttitoraccumsan tincidunt. Pellentesque in ipsum id orci porta dapibus.", true, true, 145.0, "Black T-Shirt For Woman", "fashion", "40", "[\"new\",\"s\",\"m\",\"yellow\",\"white\"]" },
                    { 2, "geox", "Women", "[\"TREND\"]", "Vivamus suscipit tortor eget felis porttitor volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin eget tortor risus. Nulla porttitoraccumsan tincidunt. Pellentesque in ipsum id orci porta dapibus.", false, false, 185.0, "T-Shirt Form Girls", "fashion", "40", "[\"s\",\"m\",\"l\",\"olive\",\"navy\"]" },
                    { 3, "nike", "Women", "[\"featured products\"]", "Vivamus suscipit tortor eget felis porttitor volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin eget tortor risus. Nulla porttitoraccumsan tincidunt. Pellentesque in ipsum id orci porta dapibus.", false, true, 174.0, "White Black Line Dress", "fashion", "20", "[\"nike\",\"l\",\"m\",\"red\",\"black\"]" },
                    { 4, "geox", "Women", "[\"on sale\"]", "Vivamus suscipit tortor eget felis porttitor volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin eget tortor risus. Nulla porttitoraccumsan tincidunt. Pellentesque in ipsum id orci porta dapibus.", true, false, 98.0, "Blue Dress For Woman", "fashion", "0", "[\"s\",\"l\",\"green\",\"skyblue\",\"geox\"]" },
                    { 5, "biba", "Women", "[\"featured products\"]", "Vivamus suscipit tortor eget felis porttitor volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin eget tortor risus. Nulla porttitoraccumsan tincidunt. Pellentesque in ipsum id orci porta dapibus.", false, true, 230.0, "Black T-Shirt For Woman", "fashion", "0", "[\"m\",\"l\",\"green\",\"black\",\"biba\"]" },
                    { 6, "max", "Women", "[\"EN \\u00C7OK SATANLAR\"]", "Vivamus suscipit tortor eget felis porttitor volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin eget tortor risus. Nulla porttitoraccumsan tincidunt. Pellentesque in ipsum id orci porta dapibus.", false, true, 121.0, "Blue Dress For Woman", "fashion", "40", "[\"new\",\"s\",\"m\",\"olive\",\"gray\"]" },
                    { 12, "nike", "Women", "[\"best sellers\",\"on sale\"]", "Vivamus suscipit tortor eget felis porttitor volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin eget tortor risus. Nulla porttitoraccumsan tincidunt. Pellentesque in ipsum id orci porta dapibus.", false, false, 129.0, "boho tops", "fashion", "40", "[\"xs\",\"s\",\"m\",\"red\",\"pink\"]" }
                });

            migrationBuilder.InsertData(
                table: "Variants",
                columns: new[] { "variant_id", "color", "id", "image_id", "size", "sku" },
                values: new object[,]
                {
                    { 101, "yellow", 1, 111, "s", "sku1" },
                    { 102, "white", 1, 112, "s", "sku2" },
                    { 201, "olive", 2, 211, "s", "sku1" },
                    { 202, "navy", 2, 212, "s", "sku2" },
                    { 301, "red", 3, 311, "l", "sku3" },
                    { 302, "red", 3, 311, "m", "skul3" },
                    { 401, "green", 4, 411, "s", "sku4" },
                    { 402, "green", 4, 411, "l", "skul4" },
                    { 501, "green", 5, 511, "m", "sku5" },
                    { 502, "green", 5, 511, "l", "skul5" },
                    { 601, "olive", 6, 611, "s", "sku6" },
                    { 602, "gray", 6, 612, "s", "skul6" },
                    { 1201, "red", 12, 1211, "xs", "sku12" },
                    { 1202, "pink", 12, 1212, "xs", "skul12" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Variants");
        }
    }
}
