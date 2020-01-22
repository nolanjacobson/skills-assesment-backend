using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace capstonebackend.Migrations
{
    public partial class AddedDateTimePlusTestName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestName",
                table: "Nurse",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeSubmitted",
                table: "Nurse",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestName",
                table: "Nurse");

            migrationBuilder.DropColumn(
                name: "TimeSubmitted",
                table: "Nurse");
        }
    }
}
