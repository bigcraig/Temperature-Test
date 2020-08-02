using Microsoft.EntityFrameworkCore.Migrations;

namespace Temperature_Test.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "CompanyID",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID1",
                table: "Employee",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Company_CompanyID1",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Employee_CompanyID1",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CompanyID1",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
