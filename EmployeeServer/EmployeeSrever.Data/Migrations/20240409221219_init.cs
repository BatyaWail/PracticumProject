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
                    { 1, 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "123456789", "Doe", true, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5125), true },
                    { 2, 2, new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "987654321", "Smith", false, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5161), true },
                    { 3, 1, new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice", "456789123", "Johnson", true, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5163), false },
                    { 4, 1, new DateTime(1988, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "111111111", "Brown", true, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5164), true },
                    { 5, 1, new DateTime(1993, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", "222222222", "Jones", false, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5166), true },
                    { 6, 1, new DateTime(1979, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "333333333", "Wilson", true, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5172), true },
                    { 7, 1, new DateTime(1996, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emma", "444444444", "Taylor", false, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5173), true },
                    { 8, 1, new DateTime(1985, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olivia", "555555555", "Anderson", false, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5175), true },
                    { 9, 1, new DateTime(1983, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel", "666666666", "Martinez", true, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5177), true },
                    { 10, 1, new DateTime(1990, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophia", "777777777", "Garcia", false, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5179), true },
                    { 11, 2, new DateTime(1976, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matthew", "888888888", "Rodriguez", true, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5180), true },
                    { 12, 2, new DateTime(1991, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isabella", "999999999", "Lopez", false, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5182), true },
                    { 13, 2, new DateTime(1980, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ethan", "101010101", "Hernandez", true, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5184), true },
                    { 14, 2, new DateTime(1994, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ava", "121212121", "Gonzalez", false, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5186), true },
                    { 15, 2, new DateTime(1989, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexander", "131313131", "Perez", true, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5187), true },
                    { 16, 2, new DateTime(1987, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mia", "141414141", "Sanchez", false, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5189), true },
                    { 17, 2, new DateTime(1992, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "151515151", "Ramirez", true, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5190), true },
                    { 18, 3, new DateTime(1984, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlotte", "161616161", "Torres", false, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5192), true },
                    { 19, 3, new DateTime(1993, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", "171717171", "Nguyen", true, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5193), true },
                    { 20, 3, new DateTime(1982, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amelia", "181818181", "Kim", false, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5195), true },
                    { 21, 3, new DateTime(1995, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benjamin", "191919191", "Tran", true, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5197), true },
                    { 22, 3, new DateTime(1986, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harper", "202020202", "Chen", false, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5199), true },
                    { 23, 3, new DateTime(1990, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jacob", "212121212", "Wang", true, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5200), true },
                    { 24, 3, new DateTime(1981, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evelyn", "222222222", "Wu", false, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5202), true }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "EmployeeId", "RoleId", "EntryDate", "IsManagementRole" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5281), true },
                    { 1, 2, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5283), false },
                    { 1, 3, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5285), false },
                    { 2, 4, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5286), true },
                    { 2, 5, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5288), false },
                    { 2, 6, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5330), false },
                    { 3, 1, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5333), true },
                    { 3, 2, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5334), false },
                    { 3, 3, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5336), false },
                    { 3, 4, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5337), true },
                    { 3, 5, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5339), false },
                    { 3, 6, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5340), false },
                    { 4, 1, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5341), true },
                    { 4, 2, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5342), false },
                    { 4, 3, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5344), false },
                    { 5, 4, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5345), true },
                    { 5, 5, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5346), false },
                    { 5, 6, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5348), false },
                    { 6, 1, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5349), true },
                    { 6, 2, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5351), false },
                    { 6, 3, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5352), false },
                    { 7, 4, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5353), true },
                    { 7, 5, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5354), false },
                    { 7, 6, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5355), false },
                    { 8, 1, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5358), true },
                    { 8, 2, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5359), false },
                    { 9, 3, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5360), false },
                    { 9, 4, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5361), true },
                    { 10, 5, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5362), false },
                    { 10, 6, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5364), false },
                    { 11, 1, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5365), true },
                    { 11, 2, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5366), false },
                    { 11, 3, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5367), false },
                    { 12, 4, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5369), true },
                    { 12, 5, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5370), false },
                    { 12, 6, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5372), false },
                    { 13, 1, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5373), true },
                    { 13, 2, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5374), false },
                    { 13, 3, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5376), false },
                    { 13, 4, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5377), true },
                    { 13, 5, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5378), false },
                    { 13, 6, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5380), false }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "EmployeeId", "RoleId", "EntryDate", "IsManagementRole" },
                values: new object[,]
                {
                    { 14, 1, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5381), true },
                    { 14, 2, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5383), false },
                    { 14, 3, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5384), false },
                    { 15, 4, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5385), true },
                    { 15, 5, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5386), false },
                    { 15, 6, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5387), false },
                    { 16, 1, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5389), true },
                    { 16, 2, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5390), false },
                    { 16, 3, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5392), false },
                    { 17, 4, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5393), true },
                    { 17, 5, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5394), false },
                    { 17, 6, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5395), false },
                    { 18, 1, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5396), true },
                    { 18, 2, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5398), false },
                    { 19, 3, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5399), false },
                    { 19, 4, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5400), true },
                    { 20, 5, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5401), false },
                    { 20, 6, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5402), false },
                    { 21, 1, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5403), true },
                    { 21, 2, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5407), false },
                    { 21, 3, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5408), false },
                    { 22, 4, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5409), true },
                    { 22, 5, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5410), false },
                    { 22, 6, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5411), false },
                    { 23, 1, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5412), true },
                    { 23, 2, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5414), false },
                    { 23, 3, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5415), false },
                    { 23, 4, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5416), true },
                    { 23, 5, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5417), false },
                    { 23, 6, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5418), false },
                    { 24, 1, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5420), true },
                    { 24, 2, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5421), false },
                    { 24, 3, new DateTime(2024, 4, 10, 1, 12, 19, 628, DateTimeKind.Local).AddTicks(5422), false }
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
