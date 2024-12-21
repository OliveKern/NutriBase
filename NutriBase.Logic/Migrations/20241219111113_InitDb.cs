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
                name: "Groceries",
                schema: "Base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KaloriesPer100Gram = table.Column<int>(type: "int", nullable: true),
                    ProteinPer100Gram = table.Column<int>(type: "int", nullable: true),
                    SugarPer100Gram = table.Column<int>(type: "int", nullable: true),
                    NutritionForm = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PackageSize = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groceries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HouseholtItems",
                schema: "Base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Material = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PackageSize = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DurationInMin = table.Column<int>(type: "int", nullable: true),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    NutritionForm = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Account",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingLists",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usage = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingLists_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Account",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroceryRecipe",
                columns: table => new
                {
                    GroceriesId = table.Column<int>(type: "int", nullable: false),
                    RecipesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryRecipe", x => new { x.GroceriesId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_GroceryRecipe_Groceries_GroceriesId",
                        column: x => x.GroceriesId,
                        principalSchema: "Base",
                        principalTable: "Groceries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroceryRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalSchema: "App",
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseholdItemRecipe",
                columns: table => new
                {
                    HouseholdItemsId = table.Column<int>(type: "int", nullable: false),
                    RecipesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdItemRecipe", x => new { x.HouseholdItemsId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_HouseholdItemRecipe_HouseholtItems_HouseholdItemsId",
                        column: x => x.HouseholdItemsId,
                        principalSchema: "Base",
                        principalTable: "HouseholtItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseholdItemRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalSchema: "App",
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroceryShoppingList",
                columns: table => new
                {
                    GroceriesId = table.Column<int>(type: "int", nullable: false),
                    ShoppingListsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryShoppingList", x => new { x.GroceriesId, x.ShoppingListsId });
                    table.ForeignKey(
                        name: "FK_GroceryShoppingList_Groceries_GroceriesId",
                        column: x => x.GroceriesId,
                        principalSchema: "Base",
                        principalTable: "Groceries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroceryShoppingList_ShoppingLists_ShoppingListsId",
                        column: x => x.ShoppingListsId,
                        principalSchema: "App",
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseholdItemShoppingList",
                columns: table => new
                {
                    HouseholdItemsId = table.Column<int>(type: "int", nullable: false),
                    ShoppingListsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdItemShoppingList", x => new { x.HouseholdItemsId, x.ShoppingListsId });
                    table.ForeignKey(
                        name: "FK_HouseholdItemShoppingList_HouseholtItems_HouseholdItemsId",
                        column: x => x.HouseholdItemsId,
                        principalSchema: "Base",
                        principalTable: "HouseholtItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseholdItemShoppingList_ShoppingLists_ShoppingListsId",
                        column: x => x.ShoppingListsId,
                        principalSchema: "App",
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_Definition",
                schema: "Base",
                table: "Groceries",
                column: "Definition",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroceryRecipe_RecipesId",
                table: "GroceryRecipe",
                column: "RecipesId");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryShoppingList_ShoppingListsId",
                table: "GroceryShoppingList",
                column: "ShoppingListsId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdItemRecipe_RecipesId",
                table: "HouseholdItemRecipe",
                column: "RecipesId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdItemShoppingList_ShoppingListsId",
                table: "HouseholdItemShoppingList",
                column: "ShoppingListsId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseholtItems_Definition",
                schema: "Base",
                table: "HouseholtItems",
                column: "Definition",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Definition",
                schema: "App",
                table: "Recipes",
                column: "Definition",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserId",
                schema: "App",
                table: "Recipes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_Definition",
                schema: "App",
                table: "ShoppingLists",
                column: "Definition",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_UserId",
                schema: "App",
                table: "ShoppingLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                schema: "Account",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroceryRecipe");

            migrationBuilder.DropTable(
                name: "GroceryShoppingList");

            migrationBuilder.DropTable(
                name: "HouseholdItemRecipe");

            migrationBuilder.DropTable(
                name: "HouseholdItemShoppingList");

            migrationBuilder.DropTable(
                name: "Groceries",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "Recipes",
                schema: "App");

            migrationBuilder.DropTable(
                name: "HouseholtItems",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "ShoppingLists",
                schema: "App");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Account");
        }
    }
}
