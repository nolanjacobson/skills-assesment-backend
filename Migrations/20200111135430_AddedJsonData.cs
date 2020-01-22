using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace capstonebackend.Migrations
{
    public partial class AddedJsonData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "JsonData",
                table: "TestData",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JsonData",
                table: "TestData");

            migrationBuilder.AddColumn<int[]>(
                name: "FrequencyRating",
                table: "TestData",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "TestData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int[]>(
                name: "ProficiencyRating",
                table: "TestData",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "Questions",
                table: "TestData",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestDataId",
                table: "TestData",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "TestData",
                type: "text",
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
    }
}
