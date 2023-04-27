using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elshad_Portfolıo.Migrations
{
    public partial class ExperinceTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "experiences",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "experiences");
        }
    }
}
