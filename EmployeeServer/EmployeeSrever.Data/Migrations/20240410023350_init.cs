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
                    { 3, "Manager" },
                    { 4, "Accountant" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "FirstName", "Identity", "LastName", "MaleOrFmale", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1983, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3465), "David", "000000001", "Zimmerman", false, new DateTime(2023, 9, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3418), true },
                    { 2, 3, new DateTime(1980, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3477), "Batya", "000000002", "Cohen", true, new DateTime(2023, 6, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3475), true },
                    { 3, 3, new DateTime(1966, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3484), "Shoshana", "000000003", "Cohen", false, new DateTime(2023, 12, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3481), true },
                    { 4, 3, new DateTime(1989, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3490), "Batya", "000000004", "Stern", false, new DateTime(2023, 7, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3488), true },
                    { 5, 1, new DateTime(1995, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3495), "Joseph", "000000005", "Gross", false, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3493), true },
                    { 6, 3, new DateTime(1990, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3502), "Hannah", "000000006", "Schwartz", false, new DateTime(2024, 3, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3499), true },
                    { 7, 1, new DateTime(2000, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3508), "Moses", "000000007", "Stern", true, new DateTime(2023, 7, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3506), true },
                    { 8, 3, new DateTime(1983, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3514), "Ruth", "000000008", "Goldberg", true, new DateTime(2024, 2, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3512), true },
                    { 9, 3, new DateTime(1985, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3519), "Esther", "000000009", "Gross", false, new DateTime(2023, 6, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3517), true },
                    { 10, 1, new DateTime(1973, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3526), "Solomon", "000000010", "Gordon", false, new DateTime(2023, 11, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3524), true },
                    { 11, 1, new DateTime(2004, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3532), "Moses", "000000011", "Friedman", false, new DateTime(2023, 12, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3530), true },
                    { 12, 1, new DateTime(1977, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3538), "Isaac", "000000012", "Cohen", false, new DateTime(2023, 6, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3536), true },
                    { 13, 1, new DateTime(1992, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3544), "Solomon", "000000013", "Schwartz", true, new DateTime(2024, 3, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3542), true },
                    { 14, 2, new DateTime(1988, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3549), "Samuel", "000000014", "Goldberg", false, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3547), true },
                    { 15, 3, new DateTime(1996, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3555), "Ruth", "000000015", "Blum", false, new DateTime(2024, 1, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3553), true },
                    { 16, 2, new DateTime(1979, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3560), "Rachel", "000000016", "Stern", false, new DateTime(2023, 11, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3558), true },
                    { 17, 2, new DateTime(1973, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3565), "Isaac", "000000017", "Geller", false, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3563), true },
                    { 18, 3, new DateTime(2004, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3571), "Aaron", "000000018", "Gordon", true, new DateTime(2023, 7, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3569), true },
                    { 19, 2, new DateTime(1987, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3576), "Isaac", "000000019", "Stern", true, new DateTime(2024, 3, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3574), true },
                    { 20, 2, new DateTime(1986, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3582), "Elijah", "000000020", "Sandler", true, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3580), true },
                    { 21, 3, new DateTime(1991, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3587), "Miriam", "000000021", "Stern", false, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3585), true },
                    { 22, 3, new DateTime(1971, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3592), "Ruth", "000000022", "Stern", true, new DateTime(2024, 2, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3590), true },
                    { 23, 2, new DateTime(1968, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3625), "Batya", "000000023", "Zimmerman", true, new DateTime(2023, 9, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3622), true },
                    { 24, 3, new DateTime(1991, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3632), "Leah", "000000024", "Sandler", false, new DateTime(2023, 7, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3629), true },
                    { 25, 1, new DateTime(1987, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3637), "Aaron", "000000025", "Geller", false, new DateTime(2023, 9, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3635), true },
                    { 26, 3, new DateTime(1992, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3643), "Hannah", "000000026", "Geller", true, new DateTime(2024, 1, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3641), true },
                    { 27, 3, new DateTime(1968, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3648), "Rachel", "000000027", "Gross", true, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3646), true },
                    { 28, 2, new DateTime(1965, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3654), "David", "000000028", "Segal", true, new DateTime(2023, 6, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3652), true },
                    { 29, 1, new DateTime(1989, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3659), "Batya", "000000029", "Weiss", false, new DateTime(2024, 2, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3657), true },
                    { 30, 2, new DateTime(1966, 4, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3664), "Shoshana", "000000030", "Cohen", true, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3663), true }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "EmployeeId", "RoleId", "EntryDate", "IsManagementRole" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 9, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3418), false },
                    { 1, 3, new DateTime(2023, 9, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3418), false },
                    { 1, 4, new DateTime(2023, 9, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3418), true },
                    { 2, 2, new DateTime(2023, 6, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3475), true },
                    { 2, 4, new DateTime(2023, 6, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3475), false },
                    { 3, 1, new DateTime(2023, 12, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3481), true },
                    { 3, 2, new DateTime(2023, 12, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3481), true },
                    { 3, 4, new DateTime(2023, 12, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3481), false },
                    { 4, 1, new DateTime(2023, 7, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3488), false },
                    { 4, 2, new DateTime(2023, 7, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3488), true },
                    { 4, 4, new DateTime(2023, 7, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3488), true },
                    { 5, 3, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3493), false },
                    { 5, 4, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3493), false },
                    { 6, 2, new DateTime(2024, 3, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3499), true },
                    { 6, 4, new DateTime(2024, 3, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3499), false },
                    { 7, 1, new DateTime(2023, 7, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3506), true },
                    { 7, 2, new DateTime(2023, 7, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3506), false },
                    { 7, 4, new DateTime(2023, 7, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3506), false },
                    { 8, 1, new DateTime(2024, 2, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3512), true },
                    { 8, 3, new DateTime(2024, 2, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3512), false },
                    { 9, 2, new DateTime(2023, 6, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3517), true },
                    { 9, 4, new DateTime(2023, 6, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3517), true },
                    { 10, 2, new DateTime(2023, 11, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3524), false },
                    { 10, 3, new DateTime(2023, 11, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3524), false },
                    { 10, 4, new DateTime(2023, 11, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3524), true },
                    { 11, 2, new DateTime(2023, 12, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3530), true },
                    { 11, 3, new DateTime(2023, 12, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3530), true },
                    { 12, 1, new DateTime(2023, 6, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3536), true },
                    { 12, 2, new DateTime(2023, 6, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3536), true },
                    { 12, 3, new DateTime(2023, 6, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3536), false },
                    { 13, 2, new DateTime(2024, 3, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3542), true },
                    { 13, 3, new DateTime(2024, 3, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3542), false },
                    { 13, 4, new DateTime(2024, 3, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3542), false },
                    { 14, 1, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3547), false },
                    { 14, 2, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3547), true },
                    { 14, 3, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3547), false },
                    { 15, 1, new DateTime(2024, 1, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3553), false },
                    { 15, 3, new DateTime(2024, 1, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3553), false },
                    { 15, 4, new DateTime(2024, 1, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3553), true },
                    { 16, 1, new DateTime(2023, 11, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3558), false },
                    { 16, 3, new DateTime(2023, 11, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3558), true },
                    { 17, 3, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3563), false }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "EmployeeId", "RoleId", "EntryDate", "IsManagementRole" },
                values: new object[,]
                {
                    { 17, 4, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3563), true },
                    { 18, 1, new DateTime(2023, 7, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3569), true },
                    { 18, 3, new DateTime(2023, 7, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3569), false },
                    { 18, 4, new DateTime(2023, 7, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3569), true },
                    { 19, 1, new DateTime(2024, 3, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3574), false },
                    { 19, 3, new DateTime(2024, 3, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3574), false },
                    { 19, 4, new DateTime(2024, 3, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3574), true },
                    { 20, 1, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3580), false },
                    { 20, 3, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3580), false },
                    { 20, 4, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3580), false },
                    { 21, 1, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3585), false },
                    { 21, 2, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3585), true },
                    { 21, 3, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3585), false },
                    { 22, 2, new DateTime(2024, 2, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3590), false },
                    { 22, 3, new DateTime(2024, 2, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3590), true },
                    { 22, 4, new DateTime(2024, 2, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3590), true },
                    { 23, 1, new DateTime(2023, 9, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3622), false },
                    { 23, 2, new DateTime(2023, 9, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3622), true },
                    { 23, 4, new DateTime(2023, 9, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3622), false },
                    { 24, 3, new DateTime(2023, 7, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3629), true },
                    { 24, 4, new DateTime(2023, 7, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3629), true },
                    { 25, 1, new DateTime(2023, 9, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3635), false },
                    { 25, 3, new DateTime(2023, 9, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3635), false },
                    { 25, 4, new DateTime(2023, 9, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3635), false },
                    { 26, 1, new DateTime(2024, 1, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3641), true },
                    { 26, 3, new DateTime(2024, 1, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3641), false },
                    { 27, 1, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3646), false },
                    { 27, 2, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3646), false },
                    { 27, 4, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3646), true },
                    { 28, 3, new DateTime(2023, 6, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3652), true },
                    { 28, 4, new DateTime(2023, 6, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3652), true },
                    { 29, 1, new DateTime(2024, 2, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3657), true },
                    { 29, 4, new DateTime(2024, 2, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3657), false },
                    { 30, 1, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3663), false },
                    { 30, 2, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3663), true },
                    { 30, 3, new DateTime(2023, 10, 10, 5, 33, 50, 739, DateTimeKind.Local).AddTicks(3663), true }
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
