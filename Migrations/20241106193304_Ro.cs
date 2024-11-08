using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class Ro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b313365-92da-4143-a499-4e0d3b3e3071", "ef5b2a33-29be-435f-812f-45491e6f455e", "User", "user" },
                    { "c620d1bf-7ab7-48d7-9728-187ad072e5b6", "1d9b9d80-13bb-402e-85ce-12c3815558ed", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b313365-92da-4143-a499-4e0d3b3e3071");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c620d1bf-7ab7-48d7-9728-187ad072e5b6");
        }
    }
}
