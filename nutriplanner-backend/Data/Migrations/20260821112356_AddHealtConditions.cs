using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriPlanner.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddHealtConditions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthConditionFoods",
                columns: table => new
                {
                    HealthConditionId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthConditionFoods", x => new { x.HealthConditionId, x.FoodId });
                    table.ForeignKey(
                        name: "FK_HealthConditionFoods_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthConditionFoods_HealthConditions_HealthConditionId",
                        column: x => x.HealthConditionId,
                        principalTable: "HealthConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DietId",
                table: "AspNetUsers",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthConditionFoods_FoodId",
                table: "HealthConditionFoods",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Diets_DietId",
                table: "AspNetUsers",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Diets_DietId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "HealthConditionFoods");

            migrationBuilder.DropTable(
                name: "HealthConditions");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DietId",
                table: "AspNetUsers");
        }
    }
}
