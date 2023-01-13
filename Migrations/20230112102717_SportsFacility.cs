using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Selin_Robert_Cristian.Migrations
{
    public partial class SportsFacility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sports_Facility",
                table: "SportsField");

            migrationBuilder.AddColumn<int>(
                name: "SportsFacilityID",
                table: "SportsField",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SportsFacility",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportsFacilityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsFacility", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportsField_SportsFacilityID",
                table: "SportsField",
                column: "SportsFacilityID");

            migrationBuilder.AddForeignKey(
                name: "FK_SportsField_SportsFacility_SportsFacilityID",
                table: "SportsField",
                column: "SportsFacilityID",
                principalTable: "SportsFacility",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportsField_SportsFacility_SportsFacilityID",
                table: "SportsField");

            migrationBuilder.DropTable(
                name: "SportsFacility");

            migrationBuilder.DropIndex(
                name: "IX_SportsField_SportsFacilityID",
                table: "SportsField");

            migrationBuilder.DropColumn(
                name: "SportsFacilityID",
                table: "SportsField");

            migrationBuilder.AddColumn<string>(
                name: "Sports_Facility",
                table: "SportsField",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
