using Microsoft.EntityFrameworkCore.Migrations;

namespace FristProjectIti.Migrations
{
    public partial class ahmamdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ahmed",
                table: "patients",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ahmed",
                table: "patients");
        }
    }
}
