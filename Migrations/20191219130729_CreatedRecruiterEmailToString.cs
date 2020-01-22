using Microsoft.EntityFrameworkCore.Migrations;

namespace capstonebackend.Migrations
{
    public partial class CreatedRecruiterEmailToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Nurse");

            migrationBuilder.AddColumn<string>(
                name: "NurseEmail",
                table: "Nurse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecruiterEmail",
                table: "Nurse",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NurseEmail",
                table: "Nurse");

            migrationBuilder.DropColumn(
                name: "RecruiterEmail",
                table: "Nurse");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Nurse",
                type: "text",
                nullable: true);
        }
    }
}
