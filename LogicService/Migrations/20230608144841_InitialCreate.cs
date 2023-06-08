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
                    { 5, new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unknown", "Samuel", null, "Jackson", null },
                    { 1, new DateTime(1961, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "tim.roth@logic.example.org", "Tim", 101, "Roth", null },
                    { 2, null, "amanda.plummer@logic.example.org", "Amanda", 102, "Plummer", null }
                });

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
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
