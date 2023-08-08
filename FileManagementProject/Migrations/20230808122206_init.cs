using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FileManagementProject.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentDepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeePassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeManagerId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName", "ParentDepartmentId" },
                values: new object[,]
                {
                    { 0, "Director", null },
                    { 1, "Purchasing Department", 0 },
                    { 2, "Purchasing Manager", 1 },
                    { 3, "Purchasing Personnel", 2 },
                    { 4, "Accounting Department", 0 },
                    { 5, "Accounting Chief", 4 },
                    { 6, "Accounting Personnel", 5 },
                    { 7, "Sales Department", 0 },
                    { 8, "Sales Chief", 7 },
                    { 9, "Sales Personnel", 8 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DepartmentId", "EmployeeEmail", "EmployeeFirstName", "EmployeeLastName", "EmployeeManagerId", "EmployeePassword" },
                values: new object[,]
                {
                    { 1, 0, "enes_bykbss@hotmail.com", "Enes", "Büyükbaş", 0, "1234" },
                    { 2, 2, "enes_buyukbas@hotmail.com", "Erhan", "Büyük", null, "12345" },
                    { 3, 3, "beyzayuksel0111@gmail.com", "Beyza", "Yüksel", null, "123456789" },
                    { 4, 5, "enes_bykbss@hotmail.com", "Emre", "Büyükbaş", null, "123564" },
                    { 5, 6, "hasanyılmaz@hotmail.com", "hasan", "yılmaz", null, "1268345" },
                    { 6, 8, "merveyuksel0111@gmail.com", "merve", "Yüksel", null, "1235456789" },
                    { 7, 9, "halilatakan@hotmail.com", "halil", "atakan", null, "123487" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
