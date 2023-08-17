using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FileManagementProject.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Departments_DepartmentId1",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepartmentId1",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67b9b2da-b6b4-4938-a432-fecbf3579aa7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7af1bd69-9ec6-4530-87f8-361da3f0eaaa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcec218b-c59f-436f-a6b4-3ca4908bf540");

            migrationBuilder.DropColumn(
                name: "DepartmentId1",
                table: "Departments");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId1",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67b9b2da-b6b4-4938-a432-fecbf3579aa7", "b3e268f6-6e63-4e65-ad23-dd6c087cfe2b", "Admin", "ADMIN" },
                    { "7af1bd69-9ec6-4530-87f8-361da3f0eaaa", "8a76ef46-0633-41dd-a5d4-0fe5f47e07d4", "User", "USER" },
                    { "dcec218b-c59f-436f-a6b4-3ca4908bf540", "de8ae4fb-92f7-4c51-802e-d98231b41999", "Director", "DIRECTOR" }
                });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 0,
                column: "DepartmentId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "DepartmentId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "DepartmentId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                column: "DepartmentId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                column: "DepartmentId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 5,
                column: "DepartmentId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 6,
                column: "DepartmentId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 7,
                column: "DepartmentId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 8,
                column: "DepartmentId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 9,
                column: "DepartmentId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentId1",
                table: "Departments",
                column: "DepartmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Departments_DepartmentId1",
                table: "Departments",
                column: "DepartmentId1",
                principalTable: "Departments",
                principalColumn: "DepartmentId");
        }
    }
}
