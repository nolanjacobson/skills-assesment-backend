using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace capstonebackend.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillsTest",
                table: "Nurse");

            migrationBuilder.DropColumn(
                name: "TimeSubmitted",
                table: "Nurse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SkillsTest",
                table: "Nurse",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeSubmitted",
                table: "Nurse",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
