using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriPlanner.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNutritionInfoKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSelections_AspNetUsers_UserId1",
                table: "UserSelections");

            migrationBuilder.DropIndex(
                name: "IX_UserSelections_UserId1",
                table: "UserSelections");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserSelections");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserSelections",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "NutritionInfo",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false),
                    Carbs = table.Column<double>(type: "float", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionInfo", x => x.FoodId);
                    table.ForeignKey(
                        name: "FK_NutritionInfo_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSelections_UserId",
                table: "UserSelections",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSelections_AspNetUsers_UserId",
                table: "UserSelections",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSelections_AspNetUsers_UserId",
                table: "UserSelections");

            migrationBuilder.DropTable(
                name: "NutritionInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserSelections_UserId",
                table: "UserSelections");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserSelections",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserSelections",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserSelections_UserId1",
                table: "UserSelections",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSelections_AspNetUsers_UserId1",
                table: "UserSelections",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
