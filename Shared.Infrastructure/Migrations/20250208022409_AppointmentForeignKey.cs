using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shared.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Appointment_IdDoctor",
                table: "Appointment",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_IdPatient",
                table: "Appointment",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_IdTimeSchedule",
                table: "Appointment",
                column: "IdTimeSchedule");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Doctor_IdDoctor",
                table: "Appointment",
                column: "IdDoctor",
                principalTable: "Doctor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patient_IdPatient",
                table: "Appointment",
                column: "IdPatient",
                principalTable: "Patient",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_TimeSchedule_IdTimeSchedule",
                table: "Appointment",
                column: "IdTimeSchedule",
                principalTable: "TimeSchedule",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Doctor_IdDoctor",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patient_IdPatient",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_TimeSchedule_IdTimeSchedule",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_IdDoctor",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_IdPatient",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_IdTimeSchedule",
                table: "Appointment");
        }
    }
}
