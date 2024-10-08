using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Angular18Demo.API.Migrations
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
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Human Resources" },
                    { 2, "IT" },
                    { 3, "Finance" },
                    { 4, "Marketing" },
                    { 5, "Sales" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DepartmentId", "Email", "EmployeeName", "Phone" },
                values: new object[,]
                {
                    { 1, 1, "john.doe@example.com", "John Doe", "1234567890" },
                    { 2, 2, "jane.smith@example.com", "Jane Smith", "0987654321" },
                    { 3, 3, "michael.johnson@example.com", "Michael Johnson", "1112223333" },
                    { 4, 4, "emily.davis@example.com", "Emily Davis", "2223334444" },
                    { 5, 5, "daniel.brown@example.com", "Daniel Brown", "3334445555" },
                    { 6, 1, "sarah.wilson@example.com", "Sarah Wilson", "4445556666" },
                    { 7, 2, "david.miller@example.com", "David Miller", "5556667777" },
                    { 8, 3, "jessica.taylor@example.com", "Jessica Taylor", "6667778888" },
                    { 9, 4, "james.anderson@example.com", "James Anderson", "7778889999" },
                    { 10, 5, "laura.martinez@example.com", "Laura Martinez", "8889990000" }
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
