using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriPlanner.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserHealthCondition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSelections");

            migrationBuilder.CreateTable(
                name: "UserFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFoods_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFoods_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserHealthConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HealthConditionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHealthConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserHealthConditions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHealthConditions_HealthConditions_HealthConditionId",
                        column: x => x.HealthConditionId,
                        principalTable: "HealthConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFoods_FoodId",
                table: "UserFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFoods_UserId_FoodId",
                table: "UserFoods",
                columns: new[] { "UserId", "FoodId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserHealthConditions_HealthConditionId",
                table: "UserHealthConditions",
                column: "HealthConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHealthConditions_UserId_HealthConditionId",
                table: "UserHealthConditions",
                columns: new[] { "UserId", "HealthConditionId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFoods");

            migrationBuilder.DropTable(
                name: "UserHealthConditions");

            migrationBuilder.CreateTable(
                name: "UserSelections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSelections_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSelections_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSelections_FoodId",
                table: "UserSelections",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSelections_UserId_FoodId",
                table: "UserSelections",
                columns: new[] { "UserId", "FoodId" },
                unique: true);
        }
    }
}
