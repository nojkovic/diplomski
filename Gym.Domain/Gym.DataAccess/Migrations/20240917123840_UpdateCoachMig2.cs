using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCoachMig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Coachs_Name",
                table: "Coachs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Coachs_Name",
                table: "Coachs",
                column: "Name",
                unique: true);
        }
    }
}
