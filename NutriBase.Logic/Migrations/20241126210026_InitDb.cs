using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriBase.Logic.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Base");

            migrationBuilder.EnsureSchema(
                name: "App");

            migrationBuilder.EnsureSchema(
                name: "Account");

            migrationBuilder.CreateTable(
                name: "HouseholtItems",
                schema: "Base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Material = table.Column<int>(type: "INTEGER", nullable: true),
                    Definition = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholtItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    DurationInMin = table.Column<int>(type: "INTEGER", nullable: false),
                    Difficulty = table.Column<int>(type: "INTEGER", nullable: false),
                    NutritionForm = table.Column<int>(type: "INTEGER", nullable: true),
                    Definition = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    TotalCost = table.Column<decimal>(type: "TEXT", nullable: false),
                    IngredientNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    WriterId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_WriterId",
                        column: x => x.WriterId,
                        principalSchema: "Account",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingLists",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Usage = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Definition = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    TotalCost = table.Column<decimal>(type: "TEXT", nullable: false),
                    IngredientNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    WriterId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingLists_Users_WriterId",
                        column: x => x.WriterId,
                        principalSchema: "Account",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Groceries",
                schema: "Base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KaloriesPer100Gram = table.Column<int>(type: "INTEGER", nullable: false),
                    ProteinPer100Gram = table.Column<int>(type: "INTEGER", nullable: false),
                    SugarPer100Gram = table.Column<int>(type: "INTEGER", nullable: false),
                    NutritionForm = table.Column<int>(type: "INTEGER", nullable: true),
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: true),
                    ShoppingListId = table.Column<int>(type: "INTEGER", nullable: true),
                    Definition = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groceries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groceries_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "App",
                        principalTable: "Recipes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Groceries_ShoppingLists_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalSchema: "App",
                        principalTable: "ShoppingLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_RecipeId",
                schema: "Base",
                table: "Groceries",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_ShoppingListId",
                schema: "Base",
                table: "Groceries",
                column: "ShoppingListId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_WriterId",
                schema: "App",
                table: "Recipes",
                column: "WriterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_WriterId",
                schema: "App",
                table: "ShoppingLists",
                column: "WriterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groceries",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "HouseholtItems",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "Recipes",
                schema: "App");

            migrationBuilder.DropTable(
                name: "ShoppingLists",
                schema: "App");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Account");
        }
    }
}
