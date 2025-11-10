using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagement.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AadharCardImagePath",
                table: "UsersDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PANCardImagePath",
                table: "UsersDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserImagePath",
                table: "UsersDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AadharCardImagePath",
                table: "UsersDetails");

            migrationBuilder.DropColumn(
                name: "PANCardImagePath",
                table: "UsersDetails");

            migrationBuilder.DropColumn(
                name: "UserImagePath",
                table: "UsersDetails");
        }
    }
}
