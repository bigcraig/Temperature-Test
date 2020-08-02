using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Temperature_Test.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Temperature = table.Column<decimal>(nullable: false),
                    MeasureDate = table.Column<DateTime>(nullable: false),
                    OfficeToday = table.Column<bool>(nullable: false),
                    OfficeTomorrow = table.Column<bool>(nullable: false),
                    Company = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "TempMeasurement",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<decimal>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    MeasureDate = table.Column<DateTime>(nullable: false),
                    OfficeToday = table.Column<bool>(nullable: false),
                    OfficeTomorrow = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempMeasurement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TempMeasurement_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TempMeasurement_EmployeeID",
                table: "TempMeasurement",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempMeasurement");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
