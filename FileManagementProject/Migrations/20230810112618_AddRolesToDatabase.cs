using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FileManagementProject.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
