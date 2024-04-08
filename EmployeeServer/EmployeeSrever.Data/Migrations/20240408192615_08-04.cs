using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSrever.Data.Migrations
{
    public partial class _0804 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmployeeRoles",
                keyColumns: new[] { "EmployeeId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "EntryDate",
                value: new DateTime(2024, 4, 8, 22, 26, 15, 465, DateTimeKind.Local).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "EmployeeRoles",
                keyColumns: new[] { "EmployeeId", "RoleId" },
                keyValues: new object[] { 2, 2 },
                column: "EntryDate",
                value: new DateTime(2024, 4, 8, 22, 26, 15, 465, DateTimeKind.Local).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "EmployeeRoles",
                keyColumns: new[] { "EmployeeId", "RoleId" },
                keyValues: new object[] { 3, 3 },
                column: "EntryDate",
                value: new DateTime(2024, 4, 8, 22, 26, 15, 465, DateTimeKind.Local).AddTicks(7548));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2024, 4, 8, 22, 26, 15, 465, DateTimeKind.Local).AddTicks(7383));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2024, 4, 8, 22, 26, 15, 465, DateTimeKind.Local).AddTicks(7431));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2024, 4, 8, 22, 26, 15, 465, DateTimeKind.Local).AddTicks(7434));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmployeeRoles",
                keyColumns: new[] { "EmployeeId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "EntryDate",
                value: new DateTime(2024, 4, 7, 15, 9, 14, 950, DateTimeKind.Local).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "EmployeeRoles",
                keyColumns: new[] { "EmployeeId", "RoleId" },
                keyValues: new object[] { 2, 2 },
                column: "EntryDate",
                value: new DateTime(2024, 4, 7, 15, 9, 14, 950, DateTimeKind.Local).AddTicks(8660));

            migrationBuilder.UpdateData(
                table: "EmployeeRoles",
                keyColumns: new[] { "EmployeeId", "RoleId" },
                keyValues: new object[] { 3, 3 },
                column: "EntryDate",
                value: new DateTime(2024, 4, 7, 15, 9, 14, 950, DateTimeKind.Local).AddTicks(8663));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2024, 4, 7, 15, 9, 14, 950, DateTimeKind.Local).AddTicks(8466));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2024, 4, 7, 15, 9, 14, 950, DateTimeKind.Local).AddTicks(8518));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2024, 4, 7, 15, 9, 14, 950, DateTimeKind.Local).AddTicks(8521));
        }
    }
}
