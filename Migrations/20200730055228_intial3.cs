using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Temperature_Test.Migrations
{
    public partial class intial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasureDate",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "OfficeToday",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "OfficeTomorrow",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Employee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MeasureDate",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "OfficeToday",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OfficeTomorrow",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Temperature",
                table: "Employee",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
