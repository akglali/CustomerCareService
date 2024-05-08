using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class dailyhoursadjust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalWeeklyHours",
                table: "EmployeesWeeklyHours");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "EmployeesWeeklyHours",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "EmployeesWeeklyHours",
                newName: "EndTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeesWeeklyHours",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EmployeesWeeklyHours");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "EmployeesWeeklyHours",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "EmployeesWeeklyHours",
                newName: "EndDate");

            migrationBuilder.AddColumn<int>(
                name: "TotalWeeklyHours",
                table: "EmployeesWeeklyHours",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
