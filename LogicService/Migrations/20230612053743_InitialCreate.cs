using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogicService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    EmployerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.EmployerId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HomeAddressId = table.Column<int>(type: "int", nullable: true),
                    PostalAddressId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Addresses_HomeAddressId",
                        column: x => x.HomeAddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Addresses_PostalAddressId",
                        column: x => x.PostalAddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEmployer",
                columns: table => new
                {
                    EmployeeEmployerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployerId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEmployer", x => x.EmployeeEmployerId);
                    table.ForeignKey(
                        name: "FK_EmployeeEmployer_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeEmployer_Employer_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employer",
                        principalColumn: "EmployerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Country", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 101, "Denver", "Usa", "40022", "Cowstreet 13" },
                    { 102, "Hollywood", "United states", "19922", "Hollywood drive 99a" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BirthDate", "EmailAddress", "FirstName", "HomeAddressId", "LastName", "PostalAddressId" },
                values: new object[,]
                {
                    { 3, null, "laura.lovelace@logic.example.org", "Laura", null, "Lovelace", null },
                    { 4, null, "Unknown", "John", null, "Travolta", null },
                    { 5, new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unknown", "Samuel", null, "Jackson", null }
                });

            migrationBuilder.InsertData(
                table: "Employer",
                columns: new[] { "EmployerId", "Deleted", "Email", "Name", "Phone", "Website" },
                values: new object[,]
                {
                    { 1, false, "info@bkb.company", "Big Kahuna Burger", "+0800bigkburger", "https://bkb.company" },
                    { 2, false, "info@jackrabbit.com", "Jack Rabbit Slim's", "0800123123", "" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BirthDate", "EmailAddress", "FirstName", "HomeAddressId", "LastName", "PostalAddressId" },
                values: new object[,]
                {
                    { 1, new DateTime(1961, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "tim.roth@logic.example.org", "Tim", 101, "Roth", null },
                    { 2, null, "amanda.plummer@logic.example.org", "Amanda", 102, "Plummer", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmployer_EmployeeId",
                table: "EmployeeEmployer",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmployer_EmployerId",
                table: "EmployeeEmployer",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_HomeAddressId",
                table: "Employees",
                column: "HomeAddressId",
                unique: true,
                filter: "[HomeAddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PostalAddressId",
                table: "Employees",
                column: "PostalAddressId",
                unique: true,
                filter: "[PostalAddressId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeEmployer");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Employer");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
