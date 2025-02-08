using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shared.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DoctorForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TimeSchedule_IdDoctor",
                table: "TimeSchedule",
                column: "IdDoctor");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSchedule_Doctor_IdDoctor",
                table: "TimeSchedule",
                column: "IdDoctor",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSchedule_Doctor_IdDoctor",
                table: "TimeSchedule");

            migrationBuilder.DropIndex(
                name: "IX_TimeSchedule_IdDoctor",
                table: "TimeSchedule");
        }
    }
}
