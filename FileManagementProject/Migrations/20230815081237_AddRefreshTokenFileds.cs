using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FileManagementProject.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenFileds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3174fe5f-44c8-4439-9045-f748db61ad4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "601f2a45-28f4-4290-ad08-590d1a74d806");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bea680da-93be-4268-8129-8bcd4b9d5b3d");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9a34a605-a2bf-472b-8d17-ecee5e48c0e4", "2f48b672-f2a8-421b-85d3-c10d064c984f", "Admin", "ADMIN" },
                    { "b5b7b7b9-e693-4e79-9109-0312ecc08049", "f62febec-3040-4f39-ba50-79752ba77db0", "Director", "DIRECTOR" },
                    { "df34b31a-ee13-40bb-9b5c-415d9ee129e4", "2912386b-c119-4f34-b409-cf6be6eff1b5", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a34a605-a2bf-472b-8d17-ecee5e48c0e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5b7b7b9-e693-4e79-9109-0312ecc08049");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df34b31a-ee13-40bb-9b5c-415d9ee129e4");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3174fe5f-44c8-4439-9045-f748db61ad4c", "8afac0b6-6692-4310-acc9-6c8c7802c2e3", "Director", "DIRECTOR" },
                    { "601f2a45-28f4-4290-ad08-590d1a74d806", "3a4c7d92-05dc-419f-bde6-b92d0fd173dc", "Admin", "ADMIN" },
                    { "bea680da-93be-4268-8129-8bcd4b9d5b3d", "9f231a0b-69af-4162-84f9-f3f61560a8f6", "User", "USER" }
                });
        }
    }
}
