using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriBase.Logic.Migrations
{
    /// <inheritdoc />
    public partial class AdaptedPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostNotAccurate",
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
                name: "TotalCost",
                schema: "App",
                table: "Recipes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CostNotAccurate",
                schema: "App",
                table: "ShoppingLists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                schema: "App",
                table: "ShoppingLists",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "CostNotAccurate",
                schema: "App",
                table: "Recipes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                schema: "App",
                table: "Recipes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
