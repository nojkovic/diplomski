using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Gyms",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Gyms_Name",
                table: "Gyms",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Gyms_Name",
                table: "Gyms");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Gyms");
        }
    }
}
