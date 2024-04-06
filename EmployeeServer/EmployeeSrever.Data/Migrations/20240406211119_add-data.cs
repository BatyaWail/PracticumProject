using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSrever.Data.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "Identity", "LastName", "MaleOrFmale", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "123456789", "Doe", true, new DateTime(2024, 4, 7, 0, 11, 19, 147, DateTimeKind.Local).AddTicks(3893), true },
                    { 2, new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "987654321", "Smith", false, new DateTime(2024, 4, 7, 0, 11, 19, 147, DateTimeKind.Local).AddTicks(3964), true },
                    { 3, new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice", "456789123", "Johnson", true, new DateTime(2024, 4, 7, 0, 11, 19, 147, DateTimeKind.Local).AddTicks(3970), false }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Manager" },
                    { 2, "Developer" },
                    { 3, "Designer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "password1", "user1" },
                    { 2, "password2", "user2" },
                    { 3, "password3", "user3" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "EmployeeId", "RoleId", "EntryDate", "IsManagementRole" },
                values: new object[] { 1, 1, new DateTime(2024, 4, 7, 0, 11, 19, 147, DateTimeKind.Local).AddTicks(4018), true });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "EmployeeId", "RoleId", "EntryDate", "IsManagementRole" },
                values: new object[] { 2, 2, new DateTime(2024, 4, 7, 0, 11, 19, 147, DateTimeKind.Local).AddTicks(4024), false });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "EmployeeId", "RoleId", "EntryDate", "IsManagementRole" },
                values: new object[] { 3, 3, new DateTime(2024, 4, 7, 0, 11, 19, 147, DateTimeKind.Local).AddTicks(4027), false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumns: new[] { "EmployeeId", "RoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumns: new[] { "EmployeeId", "RoleId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumns: new[] { "EmployeeId", "RoleId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
