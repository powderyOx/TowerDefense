using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ENTITIES_BT",
                columns: table => new
                {
                    ENTITY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DAMAGE = table.Column<int>(type: "int", nullable: false),
                    ENTITY_TYPE = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENTITIES_BT", x => x.ENTITY_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MAPS",
                columns: table => new
                {
                    MAP_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAPS", x => x.MAP_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ROUNDS",
                columns: table => new
                {
                    ROUND_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROUNDS", x => x.ROUND_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DEFENDERS",
                columns: table => new
                {
                    ENTITY_ID = table.Column<int>(type: "int", nullable: false),
                    FIRE_RATE = table.Column<int>(type: "int", nullable: false),
                    RANGE = table.Column<int>(type: "int", nullable: false),
                    COST = table.Column<int>(type: "int", nullable: false),
                    ROUND = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEFENDERS", x => x.ENTITY_ID);
                    table.ForeignKey(
                        name: "FK_DEFENDERS_ENTITIES_BT_ENTITY_ID",
                        column: x => x.ENTITY_ID,
                        principalTable: "ENTITIES_BT",
                        principalColumn: "ENTITY_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateTable(
                name: "SAVED_GAMES",
                columns: table => new
                {
                    SAVED_GAME_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MAP_ID = table.Column<int>(type: "int", nullable: false),
                    MONEY = table.Column<int>(type: "int", nullable: false),
                    ROUND = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAVED_GAMES", x => x.SAVED_GAME_ID);
                    table.ForeignKey(
                        name: "FK_SAVED_GAMES_MAPS_MAP_ID",
                        column: x => x.MAP_ID,
                        principalTable: "MAPS",
                        principalColumn: "MAP_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ATTACKERS",
                columns: table => new
                {
                    ENTITY_ID = table.Column<int>(type: "int", nullable: false),
                    SPEED = table.Column<int>(type: "int", nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false),
                    SHIELD = table.Column<int>(type: "int", nullable: false),
                    LOOT = table.Column<int>(type: "int", nullable: false),
                    ROUND_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTACKERS", x => x.ENTITY_ID);
                    table.ForeignKey(
                        name: "FK_ATTACKERS_ENTITIES_BT_ENTITY_ID",
                        column: x => x.ENTITY_ID,
                        principalTable: "ENTITIES_BT",
                        principalColumn: "ENTITY_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ATTACKERS_ROUNDS_ROUND_ID",
                        column: x => x.ROUND_ID,
                        principalTable: "ROUNDS",
                        principalColumn: "ROUND_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MAP_HAS_ENTITIES_JT",
                columns: table => new
                {
                    ENTITY_ID = table.Column<int>(type: "int", nullable: false),
                    SAVED_GAME_ID = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<int>(type: "int", nullable: true),
                    Y = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAP_HAS_ENTITIES_JT", x => new { x.ENTITY_ID, x.SAVED_GAME_ID });
                    table.ForeignKey(
                        name: "FK_MAP_HAS_ENTITIES_JT_ENTITIES_BT_ENTITY_ID",
                        column: x => x.ENTITY_ID,
                        principalTable: "ENTITIES_BT",
                        principalColumn: "ENTITY_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MAP_HAS_ENTITIES_JT_SAVED_GAMES_SAVED_GAME_ID",
                        column: x => x.SAVED_GAME_ID,
                        principalTable: "SAVED_GAMES",
                        principalColumn: "SAVED_GAME_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ATTACKERS_ROUND_ID",
                table: "ATTACKERS",
                column: "ROUND_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FIELDS_ST_MAP_ID",
                table: "FIELDS_ST",
                column: "MAP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MAP_HAS_ENTITIES_JT_SAVED_GAME_ID",
                table: "MAP_HAS_ENTITIES_JT",
                column: "SAVED_GAME_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SAVED_GAMES_MAP_ID",
                table: "SAVED_GAMES",
                column: "MAP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SAVED_GAMES_NAME",
                table: "SAVED_GAMES",
                column: "NAME",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATTACKERS");

            migrationBuilder.DropTable(
                name: "DEFENDERS");

            migrationBuilder.DropTable(
                name: "FIELDS_ST");

            migrationBuilder.DropTable(
                name: "MAP_HAS_ENTITIES_JT");

            migrationBuilder.DropTable(
                name: "ROUNDS");

            migrationBuilder.DropTable(
                name: "ENTITIES_BT");

            migrationBuilder.DropTable(
                name: "SAVED_GAMES");

            migrationBuilder.DropTable(
                name: "MAPS");
        }
    }
}
