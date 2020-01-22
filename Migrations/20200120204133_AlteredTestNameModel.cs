using Microsoft.EntityFrameworkCore.Migrations;

namespace capstonebackend.Migrations
{
    public partial class AlteredTestNameModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillsTestName",
                table: "Nurse");

            migrationBuilder.AddColumn<string>(
                name: "SkillsTest",
                table: "Nurse",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillsTest",
                table: "Nurse");

            migrationBuilder.AddColumn<string>(
                name: "SkillsTestName",
                table: "Nurse",
                type: "text",
                nullable: true);
        }
    }
}
