using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriPlanner.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExternalFoodId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExternalFoodId",
                table: "NutritionInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalFoodId",
                table: "NutritionInfos");
        }
    }
}
