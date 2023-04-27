using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elshad_Portfolıo.Migrations
{
    public partial class HardSkillsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hardSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    skill = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hardSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hardSkills_skillTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "skillTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hardSkills_TypeId",
                table: "hardSkills",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hardSkills");
        }
    }
}
