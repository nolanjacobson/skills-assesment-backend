using Microsoft.EntityFrameworkCore.Migrations;

namespace capstonebackend.Migrations
{
    public partial class AddedTestName2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestName",
                table: "Nurse");

            migrationBuilder.AddColumn<string>(
                name: "SkillsTestName",
                table: "Nurse",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillsTestName",
                table: "Nurse");

            migrationBuilder.AddColumn<string>(
                name: "TestName",
                table: "Nurse",
                type: "text",
                nullable: true);
        }
    }
}
