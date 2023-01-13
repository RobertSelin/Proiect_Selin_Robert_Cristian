using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Selin_Robert_Cristian.Migrations
{
    public partial class SportsFieldType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SportsFieldType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportsFieldID = table.Column<int>(type: "int", nullable: false),
                    TypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsFieldType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SportsFieldType_SportsField_SportsFieldID",
                        column: x => x.SportsFieldID,
                        principalTable: "SportsField",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportsFieldType_Type_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Type",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportsFieldType_SportsFieldID",
                table: "SportsFieldType",
                column: "SportsFieldID");

            migrationBuilder.CreateIndex(
                name: "IX_SportsFieldType_TypeID",
                table: "SportsFieldType",
                column: "TypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportsFieldType");

            migrationBuilder.DropTable(
                name: "Type");
        }
    }
}
