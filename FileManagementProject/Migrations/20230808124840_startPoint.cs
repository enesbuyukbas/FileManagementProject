using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileManagementProject.Migrations
{
    /// <inheritdoc />
    public partial class startPoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                columns: new[] { "EmployeeEmail", "EmployeeFirstName", "EmployeeLastName" },
                values: new object[] { "beyzayuksel0111@gmail.com", "Beyza", "Yüksel" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                columns: new[] { "EmployeeEmail", "EmployeeFirstName", "EmployeeLastName" },
                values: new object[] { "erhanyılmaz@gmail.com", "erhan", "yılmaz" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                columns: new[] { "EmployeeEmail", "EmployeeFirstName", "EmployeeLastName" },
                values: new object[] { "enes_buyukbas@hotmail.com", "Erhan", "Büyük" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                columns: new[] { "EmployeeEmail", "EmployeeFirstName", "EmployeeLastName" },
                values: new object[] { "beyzayuksel0111@gmail.com", "Beyza", "Yüksel" });
        }
    }
}
