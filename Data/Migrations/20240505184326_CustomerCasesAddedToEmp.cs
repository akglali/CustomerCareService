using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CustomerCasesAddedToEmp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EmployeeId",
                table: "CustomersCases",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_CustomersCases_EmployeeId",
                table: "CustomersCases",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersCases_Employees_EmployeeId",
                table: "CustomersCases",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomersCases_Employees_EmployeeId",
                table: "CustomersCases");

            migrationBuilder.DropIndex(
                name: "IX_CustomersCases_EmployeeId",
                table: "CustomersCases");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "CustomersCases");
        }
    }
}
