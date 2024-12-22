using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriBase.Logic.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesAdaptation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Usage",
                schema: "App",
                table: "ShoppingLists",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CostNotAccurate",
                schema: "App",
                table: "ShoppingLists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "GoodsNumber",
                schema: "App",
                table: "ShoppingLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                schema: "App",
                table: "ShoppingLists",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                schema: "App",
                table: "Recipes",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CostNotAccurate",
                schema: "App",
                table: "Recipes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "IngredientNumber",
                schema: "App",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                schema: "App",
                table: "Recipes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Valuation",
                schema: "App",
                table: "Recipes",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostNotAccurate",
                schema: "App",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "GoodsNumber",
                schema: "App",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                schema: "App",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "CostNotAccurate",
                schema: "App",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IngredientNumber",
                schema: "App",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                schema: "App",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Valuation",
                schema: "App",
                table: "Recipes");

            migrationBuilder.AlterColumn<string>(
                name: "Usage",
                schema: "App",
                table: "ShoppingLists",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                schema: "App",
                table: "Recipes",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);
        }
    }
}
