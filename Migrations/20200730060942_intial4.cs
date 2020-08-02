using Microsoft.EntityFrameworkCore.Migrations;

namespace Temperature_Test.Migrations
{
    public partial class intial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Company_CompanyID1",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_CompanyID1",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CompanyID1",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyID",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyID",
                table: "Employee",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Company_CompanyID",
                table: "Employee",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Company_CompanyID",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_CompanyID",
                table: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyID",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CompanyID1",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyID1",
                table: "Employee",
                column: "CompanyID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Company_CompanyID1",
                table: "Employee",
                column: "CompanyID1",
                principalTable: "Company",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
