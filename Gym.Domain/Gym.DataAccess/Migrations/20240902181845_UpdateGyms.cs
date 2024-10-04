using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGyms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GymId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_GymId",
                table: "Appointments",
                column: "GymId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Gyms_GymId",
                table: "Appointments",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Gyms_GymId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_GymId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "Appointments");
        }
    }
}
