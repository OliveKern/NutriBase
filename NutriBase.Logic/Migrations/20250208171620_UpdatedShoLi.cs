using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriBase.Logic.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedShoLi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoodsNumber",
                schema: "App",
                table: "ShoppingLists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoodsNumber",
                schema: "App",
                table: "ShoppingLists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
