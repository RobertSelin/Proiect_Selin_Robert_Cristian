using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Selin_Robert_Cristian.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SportsField",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Field_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price_Per_Hour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sports_Facility = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsField", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportsField");
        }
    }
}
