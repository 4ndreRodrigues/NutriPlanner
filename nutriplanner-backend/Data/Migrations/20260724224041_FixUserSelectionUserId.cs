using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriPlanner.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixUserSelectionUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSelections_AspNetUsers_ApplicationUserId",
                table: "UserSelections");

            migrationBuilder.DropIndex(
                name: "IX_UserSelections_ApplicationUserId",
                table: "UserSelections");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserSelections");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Foods",
                newName: "ExternalFoodId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Diets",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserSelections",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserSelections",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSelections_FoodId",
                table: "UserSelections",
                column: "FoodId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserSelections_Foods_FoodId",
                table: "UserSelections",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSelections_AspNetUsers_UserId1",
                table: "UserSelections");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSelections_Foods_FoodId",
                table: "UserSelections");

            migrationBuilder.DropIndex(
                name: "IX_UserSelections_FoodId",
                table: "UserSelections");

            migrationBuilder.DropIndex(
                name: "IX_UserSelections_UserId1",
                table: "UserSelections");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserSelections");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "ExternalFoodId",
                table: "Foods",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Diets",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserSelections",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserSelections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserSelections_ApplicationUserId",
                table: "UserSelections",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSelections_AspNetUsers_ApplicationUserId",
                table: "UserSelections",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
