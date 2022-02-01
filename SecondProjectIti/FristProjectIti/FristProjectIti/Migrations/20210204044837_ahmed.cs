using Microsoft.EntityFrameworkCore.Migrations;

namespace FristProjectIti.Migrations
{
    public partial class ahmed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NationalNumberCard",
                table: "patients",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NationalNumberCard",
                table: "patients");
        }
    }
}
