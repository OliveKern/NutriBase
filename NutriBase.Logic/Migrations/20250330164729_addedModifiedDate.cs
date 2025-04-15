using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriBase.Logic.Migrations
{
    /// <inheritdoc />
    public partial class addedModifiedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "App",
                table: "ShoppingLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "App",
                table: "Recipes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "App",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "App",
                table: "Recipes");
        }
    }
}
