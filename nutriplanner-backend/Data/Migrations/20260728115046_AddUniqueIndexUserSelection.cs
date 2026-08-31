using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriPlanner.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexUserSelection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserSelections_UserId",
                table: "UserSelections");

            migrationBuilder.CreateIndex(
                name: "IX_UserSelections_UserId_FoodId",
                table: "UserSelections",
                columns: new[] { "UserId", "FoodId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserSelections_UserId_FoodId",
                table: "UserSelections");

            migrationBuilder.CreateIndex(
                name: "IX_UserSelections_UserId",
                table: "UserSelections",
                column: "UserId");
        }
    }
}
