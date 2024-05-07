using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class weeklyhoursAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesWeeklyHours_EmployeesWeeklyHours_WeeklyHoursId",
                table: "EmployeesWeeklyHours");

            migrationBuilder.DropIndex(
                name: "IX_EmployeesWeeklyHours_WeeklyHoursId",
                table: "EmployeesWeeklyHours");

            migrationBuilder.DropColumn(
                name: "WeeklyHoursId",
                table: "EmployeesWeeklyHours");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeeklyHoursId",
                table: "EmployeesWeeklyHours",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesWeeklyHours_WeeklyHoursId",
                table: "EmployeesWeeklyHours",
                column: "WeeklyHoursId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesWeeklyHours_EmployeesWeeklyHours_WeeklyHoursId",
                table: "EmployeesWeeklyHours",
                column: "WeeklyHoursId",
                principalTable: "EmployeesWeeklyHours",
                principalColumn: "Id");
        }
    }
}
