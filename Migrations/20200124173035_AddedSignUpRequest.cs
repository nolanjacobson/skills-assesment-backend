using Microsoft.EntityFrameworkCore.Migrations;

namespace capstonebackend.Migrations
{
    public partial class AddedSignUpRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecretHash",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecretHash",
                table: "Users");
        }
    }
}
