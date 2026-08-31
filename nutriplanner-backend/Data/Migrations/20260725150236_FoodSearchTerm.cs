using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriPlanner.Data.Migrations
{
    /// <inheritdoc />
    public partial class FoodSearchTerm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NutritionInfo_Foods_FoodId",
                table: "NutritionInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NutritionInfo",
                table: "NutritionInfo");

            migrationBuilder.RenameTable(
                name: "NutritionInfo",
                newName: "NutritionInfos");

            migrationBuilder.AddColumn<string>(
                name: "SearchTerm",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NutritionInfos",
                table: "NutritionInfos",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_NutritionInfos_Foods_FoodId",
                table: "NutritionInfos",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NutritionInfos_Foods_FoodId",
                table: "NutritionInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NutritionInfos",
                table: "NutritionInfos");

            migrationBuilder.DropColumn(
                name: "SearchTerm",
                table: "Foods");

            migrationBuilder.RenameTable(
                name: "NutritionInfos",
                newName: "NutritionInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NutritionInfo",
                table: "NutritionInfo",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_NutritionInfo_Foods_FoodId",
                table: "NutritionInfo",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
