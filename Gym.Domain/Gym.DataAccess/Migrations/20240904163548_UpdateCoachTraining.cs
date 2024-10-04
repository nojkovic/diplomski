using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCoachTraining : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GymId",
                table: "CoachTrainings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CoachTrainings_GymId",
                table: "CoachTrainings",
                column: "GymId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoachTrainings_Gyms_GymId",
                table: "CoachTrainings",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoachTrainings_Gyms_GymId",
                table: "CoachTrainings");

            migrationBuilder.DropIndex(
                name: "IX_CoachTrainings_GymId",
                table: "CoachTrainings");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "CoachTrainings");
        }
    }
}
