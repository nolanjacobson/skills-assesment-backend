using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace capstonebackend.Migrations
{
    public partial class NewRecruiterModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecruitersNames",
                table: "Recruiter");

            migrationBuilder.AddColumn<string>(
                name: "RecruiterEmail",
                table: "Recruiter",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecruiterName",
                table: "Recruiter",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecruiterEmail",
                table: "Recruiter");

            migrationBuilder.DropColumn(
                name: "RecruiterName",
                table: "Recruiter");

            migrationBuilder.AddColumn<string[]>(
                name: "RecruitersNames",
                table: "Recruiter",
                type: "text[]",
                nullable: true);
        }
    }
}
