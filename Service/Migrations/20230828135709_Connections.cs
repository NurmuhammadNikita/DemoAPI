using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class Connections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_EmployeeId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStaff_Employees_EmployeesId",
                table: "EmployeeStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStaff_Staffs_StaffsId",
                table: "EmployeeStaff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeStaff",
                table: "EmployeeStaff");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "StaffsId",
                table: "EmployeeStaff",
                newName: "StaffId");

            migrationBuilder.RenameColumn(
                name: "EmployeesId",
                table: "EmployeeStaff",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeStaff_StaffsId",
                table: "EmployeeStaff",
                newName: "IX_EmployeeStaff_StaffId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "EmployeeStaff",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeStaff",
                table: "EmployeeStaff",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeStaff_EmployeeId",
                table: "EmployeeStaff",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStaff_Employees_EmployeeId",
                table: "EmployeeStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStaff_Staffs_StaffId",
                table: "EmployeeStaff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeStaff",
                table: "EmployeeStaff");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeStaff_EmployeeId",
                table: "EmployeeStaff");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmployeeStaff");

            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "EmployeeStaff",
                newName: "StaffsId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "EmployeeStaff",
                newName: "EmployeesId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeStaff_StaffId",
                table: "EmployeeStaff",
                newName: "IX_EmployeeStaff_StaffsId");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Employees",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeStaff",
                table: "EmployeeStaff",
                columns: new[] { "EmployeesId", "StaffsId" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_EmployeeId",
                table: "Employees",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeStaff_Employees_EmployeesId",
                table: "EmployeeStaff",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeStaff_Staffs_StaffsId",
                table: "EmployeeStaff",
                column: "StaffsId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
