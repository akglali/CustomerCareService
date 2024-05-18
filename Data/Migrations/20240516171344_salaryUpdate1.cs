using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class salaryUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndingPeriod",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "StartingPeriod",
                table: "Salaries");

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "Salaries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "PaidAmount",
                table: "Salaries",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalHour",
                table: "Salaries",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "PaidAmount",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "TotalHour",
                table: "Salaries");

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
        }
    }
}
