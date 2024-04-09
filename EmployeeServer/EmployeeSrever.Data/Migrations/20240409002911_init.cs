using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSrever.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaleOrFmale = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsManagementRole = table.Column<bool>(type: "bit", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => new { x.EmployeeId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "company1", "123456" },
                    { 2, "company2", "123456" },
                    { 3, "company3", "123456" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Developer" },
                    { 2, "Designer" },
                    { 3, "Accountant" },
                    { 4, "Sales Representative" },
                    { 5, "Customer Service Representative" },
                    { 6, "Human Resources Specialist" },
                    { 7, "Marketing Coordinator" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "FirstName", "Identity", "LastName", "MaleOrFmale", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "123456789", "Doe", true, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5792), true },
                    { 2, 2, new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "987654321", "Smith", false, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5826), true },
                    { 3, 1, new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice", "456789123", "Johnson", true, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5828), false },
                    { 4, 1, new DateTime(1988, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "111111111", "Brown", true, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5830), true },
                    { 5, 1, new DateTime(1993, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", "222222222", "Jones", false, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5832), true },
                    { 6, 1, new DateTime(1979, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "333333333", "Wilson", true, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5833), true },
                    { 7, 1, new DateTime(1996, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emma", "444444444", "Taylor", false, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5835), true },
                    { 8, 1, new DateTime(1985, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olivia", "555555555", "Anderson", false, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5836), true },
                    { 9, 1, new DateTime(1983, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel", "666666666", "Martinez", true, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5839), true },
                    { 10, 1, new DateTime(1990, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophia", "777777777", "Garcia", false, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5841), true },
                    { 11, 2, new DateTime(1976, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matthew", "888888888", "Rodriguez", true, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5842), true },
                    { 12, 2, new DateTime(1991, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isabella", "999999999", "Lopez", false, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5844), true },
                    { 13, 2, new DateTime(1980, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ethan", "101010101", "Hernandez", true, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5845), true },
                    { 14, 2, new DateTime(1994, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ava", "121212121", "Gonzalez", false, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5847), true },
                    { 15, 2, new DateTime(1989, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexander", "131313131", "Perez", true, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5849), true },
                    { 16, 2, new DateTime(1987, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mia", "141414141", "Sanchez", false, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5851), true },
                    { 17, 2, new DateTime(1992, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "151515151", "Ramirez", true, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5852), true },
                    { 18, 3, new DateTime(1984, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlotte", "161616161", "Torres", false, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5854), true },
                    { 19, 3, new DateTime(1993, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", "171717171", "Nguyen", true, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5855), true },
                    { 20, 3, new DateTime(1982, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amelia", "181818181", "Kim", false, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5857), true },
                    { 21, 3, new DateTime(1995, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benjamin", "191919191", "Tran", true, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5862), true },
                    { 22, 3, new DateTime(1986, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harper", "202020202", "Chen", false, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5864), true },
                    { 23, 3, new DateTime(1990, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jacob", "212121212", "Wang", true, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5865), true },
                    { 24, 3, new DateTime(1981, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evelyn", "222222222", "Wu", false, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(5867), true }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "EmployeeId", "RoleId", "EntryDate", "IsManagementRole" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6032), true },
                    { 1, 2, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6034), false },
                    { 1, 3, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6036), false },
                    { 2, 4, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6037), true },
                    { 2, 5, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6038), false },
                    { 2, 6, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6040), false },
                    { 3, 1, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6041), true },
                    { 3, 2, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6042), false },
                    { 3, 3, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6044), false },
                    { 3, 4, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6046), true },
                    { 3, 5, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6047), false },
                    { 3, 6, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6049), false },
                    { 4, 1, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6050), true },
                    { 4, 2, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6052), false },
                    { 4, 3, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6053), false },
                    { 5, 4, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6054), true },
                    { 5, 5, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6056), false },
                    { 5, 6, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6057), false },
                    { 6, 1, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6059), true },
                    { 6, 2, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6060), false },
                    { 6, 3, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6061), false },
                    { 7, 4, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6063), true },
                    { 7, 5, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6064), false },
                    { 7, 6, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6065), false },
                    { 8, 1, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6066), true },
                    { 8, 2, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6068), false },
                    { 9, 3, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6069), false },
                    { 9, 4, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6070), true },
                    { 10, 5, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6072), false },
                    { 10, 6, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6073), false },
                    { 11, 1, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6074), true },
                    { 11, 2, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6076), false },
                    { 11, 3, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6077), false },
                    { 12, 4, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6078), true },
                    { 12, 5, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6080), false },
                    { 12, 6, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6082), false },
                    { 13, 1, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6083), true },
                    { 13, 2, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6084), false },
                    { 13, 3, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6086), false },
                    { 13, 4, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6087), true },
                    { 13, 5, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6088), false },
                    { 13, 6, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6089), false }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "EmployeeId", "RoleId", "EntryDate", "IsManagementRole" },
                values: new object[,]
                {
                    { 14, 1, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6091), true },
                    { 14, 2, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6092), false },
                    { 14, 3, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6093), false },
                    { 15, 4, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6095), true },
                    { 15, 5, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6096), false },
                    { 15, 6, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6100), false },
                    { 16, 1, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6101), true },
                    { 16, 2, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6102), false },
                    { 16, 3, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6104), false },
                    { 17, 4, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6105), true },
                    { 17, 5, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6106), false },
                    { 17, 6, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6108), false },
                    { 18, 1, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6109), true },
                    { 18, 2, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6110), false },
                    { 19, 3, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6112), false },
                    { 19, 4, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6113), true },
                    { 20, 5, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6114), false },
                    { 20, 6, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6116), false },
                    { 21, 1, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6117), true },
                    { 21, 2, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6118), false },
                    { 21, 3, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6120), false },
                    { 22, 4, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6121), true },
                    { 22, 5, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6123), false },
                    { 22, 6, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6124), false },
                    { 23, 1, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6125), true },
                    { 23, 2, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6127), false },
                    { 23, 3, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6128), false },
                    { 23, 4, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6129), true },
                    { 23, 5, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6130), false },
                    { 23, 6, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6132), false },
                    { 24, 1, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6133), true },
                    { 24, 2, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6134), false },
                    { 24, 3, new DateTime(2024, 4, 9, 3, 29, 10, 830, DateTimeKind.Local).AddTicks(6136), false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_RoleId",
                table: "EmployeeRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
