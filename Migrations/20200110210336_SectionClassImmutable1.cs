using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace capstonebackend.Migrations
{
    public partial class SectionClassImmutable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.AddColumn<List<int>>(
                name: "FrequencyRating",
                table: "TestData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "TestData",
                nullable: true);

            migrationBuilder.AddColumn<List<int>>(
                name: "ProficiencyRating",
                table: "TestData",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "Questions",
                table: "TestData",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestDataId",
                table: "TestData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "TestData",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TestData_TestDataId",
                table: "TestData",
                column: "TestDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestData_TestData_TestDataId",
                table: "TestData",
                column: "TestDataId",
                principalTable: "TestData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestData_TestData_TestDataId",
                table: "TestData");

            migrationBuilder.DropIndex(
                name: "IX_TestData_TestDataId",
                table: "TestData");

            migrationBuilder.DropColumn(
                name: "FrequencyRating",
                table: "TestData");

            migrationBuilder.DropColumn(
                name: "Header",
                table: "TestData");

            migrationBuilder.DropColumn(
                name: "ProficiencyRating",
                table: "TestData");

            migrationBuilder.DropColumn(
                name: "Questions",
                table: "TestData");

            migrationBuilder.DropColumn(
                name: "TestDataId",
                table: "TestData");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "TestData");

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FrequencyRating = table.Column<int>(type: "integer", nullable: false),
                    ProficiencyRating = table.Column<int>(type: "integer", nullable: false),
                    TestDataId = table.Column<int>(type: "integer", nullable: true),
                    header = table.Column<string>(type: "text", nullable: true),
                    questions = table.Column<List<string>>(type: "text[]", nullable: true)
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
    }
}
