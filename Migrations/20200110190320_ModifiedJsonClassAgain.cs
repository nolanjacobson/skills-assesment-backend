using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace capstonebackend.Migrations
{
    public partial class ModifiedJsonClassAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrequencyRating",
                table: "TestData");

            migrationBuilder.DropColumn(
                name: "ProficiencyRating",
                table: "TestData");

            migrationBuilder.DropColumn(
                name: "header",
                table: "TestData");

            migrationBuilder.DropColumn(
                name: "questions",
                table: "TestData");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TestData",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    header = table.Column<string>(nullable: true),
                    questions = table.Column<List<string>>(nullable: true),
                    ProficiencyRating = table.Column<int>(nullable: false),
                    FrequencyRating = table.Column<int>(nullable: false),
                    TestDataId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_TestData_TestDataId",
                        column: x => x.TestDataId,
                        principalTable: "TestData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Section_TestDataId",
                table: "Section",
                column: "TestDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TestData",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "FrequencyRating",
                table: "TestData",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProficiencyRating",
                table: "TestData",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "header",
                table: "TestData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "questions",
                table: "TestData",
                type: "text[]",
                nullable: true);
        }
    }
}
