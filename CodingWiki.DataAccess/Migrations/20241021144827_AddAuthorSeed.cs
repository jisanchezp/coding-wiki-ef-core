using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName", "Location" },
                values: new object[,]
                {
                    { 1, new DateTime(1979, 6, 21, 11, 48, 26, 787, DateTimeKind.Local).AddTicks(5490), "Juan", "Doe", "TX" },
                    { 2, new DateTime(2001, 4, 21, 11, 48, 26, 787, DateTimeKind.Local).AddTicks(5507), "Douglas", "Perez", "AR" },
                    { 3, new DateTime(1964, 8, 21, 11, 48, 26, 787, DateTimeKind.Local).AddTicks(5509), "Martina", "Smith", "MS" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
