using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class dailyhoursadjust3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesWeeklyHours_Employees_EmployeeId",
                table: "EmployeesWeeklyHours");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesWeeklyHours_Salaries_SalaryId",
                table: "EmployeesWeeklyHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeesWeeklyHours",
                table: "EmployeesWeeklyHours");

            migrationBuilder.RenameTable(
                name: "EmployeesWeeklyHours",
                newName: "EmployeesDailyHours");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeesWeeklyHours_SalaryId",
                table: "EmployeesDailyHours",
                newName: "IX_EmployeesDailyHours_SalaryId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeesWeeklyHours_EmployeeId",
                table: "EmployeesDailyHours",
                newName: "IX_EmployeesDailyHours_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeesDailyHours",
                table: "EmployeesDailyHours",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesDailyHours_Employees_EmployeeId",
                table: "EmployeesDailyHours",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesDailyHours_Salaries_SalaryId",
                table: "EmployeesDailyHours",
                column: "SalaryId",
                principalTable: "Salaries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesDailyHours_Employees_EmployeeId",
                table: "EmployeesDailyHours");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesDailyHours_Salaries_SalaryId",
                table: "EmployeesDailyHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeesDailyHours",
                table: "EmployeesDailyHours");

            migrationBuilder.RenameTable(
                name: "EmployeesDailyHours",
                newName: "EmployeesWeeklyHours");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeesDailyHours_SalaryId",
                table: "EmployeesWeeklyHours",
                newName: "IX_EmployeesWeeklyHours_SalaryId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeesDailyHours_EmployeeId",
                table: "EmployeesWeeklyHours",
                newName: "IX_EmployeesWeeklyHours_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeesWeeklyHours",
                table: "EmployeesWeeklyHours",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesWeeklyHours_Employees_EmployeeId",
                table: "EmployeesWeeklyHours",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesWeeklyHours_Salaries_SalaryId",
                table: "EmployeesWeeklyHours",
                column: "SalaryId",
                principalTable: "Salaries",
                principalColumn: "Id");
        }
    }
}
