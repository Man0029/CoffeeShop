using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "~/assets/images/anna-bratiychuk-3w2aurzeesu-unsplash-815x1223.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp");
        }
    }
}
