using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FileManagementProject.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1122400d-f37c-4891-9f04-551cde2bdf21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "297210e3-f9eb-4584-b205-c45d4accbca8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9dfb7f5-748b-43de-b344-c2aaa4ef9a32");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4c42c603-7e9a-41be-b745-b420a085fdd5", "43957515-7381-4ef4-9f8b-c9cf2a61677c", "Admin", "ADMIN" },
                    { "a68056a9-f626-4202-ab12-d88838bb57b4", "d49017c1-254b-48c5-96ed-8bb353afa733", "Director", "DIRECTOR" },
                    { "de2f3720-88c1-4d75-873c-5624715086b7", "6caf2408-4d25-432f-8b29-d823d059a574", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c42c603-7e9a-41be-b745-b420a085fdd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a68056a9-f626-4202-ab12-d88838bb57b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de2f3720-88c1-4d75-873c-5624715086b7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1122400d-f37c-4891-9f04-551cde2bdf21", "a6845321-a2a9-4c43-9252-128710ff57af", "User", "USER" },
                    { "297210e3-f9eb-4584-b205-c45d4accbca8", "bf7c45ef-236e-4ca9-84df-51a097406dca", "Admin", "ADMIN" },
                    { "e9dfb7f5-748b-43de-b344-c2aaa4ef9a32", "698ee147-2615-4806-adda-2580167d4de9", "Director", "DIRECTOR" }
                });
        }
    }
}
