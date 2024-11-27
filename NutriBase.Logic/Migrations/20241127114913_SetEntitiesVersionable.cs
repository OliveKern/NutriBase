using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriBase.Logic.Migrations
{
    /// <inheritdoc />
    public partial class SetEntitiesVersionable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "Account",
                table: "Users",
                type: "BLOB",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "App",
                table: "ShoppingLists",
                type: "BLOB",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "App",
                table: "Recipes",
                type: "BLOB",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "Base",
                table: "HouseholtItems",
                type: "BLOB",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "Base",
                table: "Groceries",
                type: "BLOB",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "Account",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "App",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "App",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "Base",
                table: "HouseholtItems");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "Base",
                table: "Groceries");
        }
    }
}
