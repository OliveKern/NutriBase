using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriBase.Logic.Migrations
{
    /// <inheritdoc />
    public partial class AddIndizes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                schema: "Account",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Definition",
                table: "Product",
                column: "Definition",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plan_Definition",
                table: "Plan",
                column: "Definition",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                schema: "Account",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Product_Definition",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Plan_Definition",
                table: "Plan");
        }
    }
}
