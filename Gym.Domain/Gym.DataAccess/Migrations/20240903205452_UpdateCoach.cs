using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCoach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GymId",
                table: "Coachs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Coachs_GymId",
                table: "Coachs",
                column: "GymId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coachs_Gyms_GymId",
                table: "Coachs",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coachs_Gyms_GymId",
                table: "Coachs");

            migrationBuilder.DropIndex(
                name: "IX_Coachs_GymId",
                table: "Coachs");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "Coachs");
        }
    }
}
