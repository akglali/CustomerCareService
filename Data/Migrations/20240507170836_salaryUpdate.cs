using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class salaryUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndingPeriod",
                table: "Salaries",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingPeriod",
                table: "Salaries",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "SalaryId",
                table: "EmployeesWeeklyHours",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesWeeklyHours_SalaryId",
                table: "EmployeesWeeklyHours",
                column: "SalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesWeeklyHours_Salaries_SalaryId",
                table: "EmployeesWeeklyHours",
                column: "SalaryId",
                principalTable: "Salaries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesWeeklyHours_Salaries_SalaryId",
                table: "EmployeesWeeklyHours");

            migrationBuilder.DropIndex(
                name: "IX_EmployeesWeeklyHours_SalaryId",
                table: "EmployeesWeeklyHours");

            migrationBuilder.DropColumn(
                name: "EndingPeriod",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "StartingPeriod",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "SalaryId",
                table: "EmployeesWeeklyHours");
        }
    }
}
