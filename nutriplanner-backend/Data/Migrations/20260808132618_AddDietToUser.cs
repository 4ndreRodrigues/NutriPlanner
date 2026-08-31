using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriPlanner.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDietToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DietId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DietId",
                table: "AspNetUsers");
        }
    }
}
