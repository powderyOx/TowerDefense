using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class map : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FIELDS_ST",
                columns: table => new
                {
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    MAP_ID = table.Column<int>(type: "int", nullable: false),
                    FIELD_TYPE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FIELDS_ST", x => new { x.X, x.Y });
                    table.ForeignKey(
                        name: "FK_FIELDS_ST_MAPS_MAP_ID",
                        column: x => x.MAP_ID,
                        principalTable: "MAPS",
                        principalColumn: "MAP_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FIELDS_ST_MAP_ID",
                table: "FIELDS_ST",
                column: "MAP_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FIELDS_ST");
        }
    }
}
