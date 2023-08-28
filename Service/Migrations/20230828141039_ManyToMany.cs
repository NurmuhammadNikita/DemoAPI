using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStaff_Employees_EmployeeId",
                table: "EmployeeStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStaff_Staffs_StaffId",
                table: "EmployeeStaff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeStaff",
                table: "EmployeeStaff");

            migrationBuilder.RenameTable(
                name: "EmployeeStaff",
                newName: "EmployeesStaff");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeStaff_StaffId",
                table: "EmployeesStaff",
                newName: "IX_EmployeesStaff_StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeStaff_EmployeeId",
                table: "EmployeesStaff",
                newName: "IX_EmployeesStaff_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeesStaff",
                table: "EmployeesStaff",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesStaff_Employees_EmployeeId",
                table: "EmployeesStaff",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesStaff_Staffs_StaffId",
                table: "EmployeesStaff",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesStaff_Employees_EmployeeId",
                table: "EmployeesStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesStaff_Staffs_StaffId",
                table: "EmployeesStaff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeesStaff",
                table: "EmployeesStaff");

            migrationBuilder.RenameTable(
                name: "EmployeesStaff",
                newName: "EmployeeStaff");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeesStaff_StaffId",
                table: "EmployeeStaff",
                newName: "IX_EmployeeStaff_StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeesStaff_EmployeeId",
                table: "EmployeeStaff",
                newName: "IX_EmployeeStaff_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeStaff",
                table: "EmployeeStaff",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeStaff_Employees_EmployeeId",
                table: "EmployeeStaff",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeStaff_Staffs_StaffId",
                table: "EmployeeStaff",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
