﻿using Microsoft.EntityFrameworkCore.Metadata;
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
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NAME = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
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
                name: "SAVED_GAMES",
                columns: table => new
                {
                    SAVED_GAME_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MONEY = table.Column<int>(type: "int", nullable: false),
                    ROUND = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAVED_GAMES", x => x.SAVED_GAME_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DEFENDERS",
                columns: table => new
                {
                    ENTITY_ID = table.Column<int>(type: "int", nullable: false),
                    DEFENDER_ID = table.Column<int>(type: "int", nullable: false),
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
                name: "ATTACKERS",
                columns: table => new
                {
                    ENTITY_ID = table.Column<int>(type: "int", nullable: false),
                    ATTACKER_ID = table.Column<int>(type: "int", nullable: false),
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
                name: "MAP_HAS_ENTITIES",
                columns: table => new
                {
                    MAP_ID = table.Column<int>(type: "int", nullable: false),
                    ENTITY_ID = table.Column<int>(type: "int", nullable: false),
                    SAVED_GAME_ID = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAP_HAS_ENTITIES", x => new { x.ENTITY_ID, x.MAP_ID, x.SAVED_GAME_ID });
                    table.ForeignKey(
                        name: "FK_MAP_HAS_ENTITIES_ENTITIES_BT_ENTITY_ID",
                        column: x => x.ENTITY_ID,
                        principalTable: "ENTITIES_BT",
                        principalColumn: "ENTITY_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MAP_HAS_ENTITIES_MAPS_MAP_ID",
                        column: x => x.MAP_ID,
                        principalTable: "MAPS",
                        principalColumn: "MAP_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MAP_HAS_ENTITIES_SAVED_GAMES_SAVED_GAME_ID",
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
                name: "IX_MAP_HAS_ENTITIES_MAP_ID",
                table: "MAP_HAS_ENTITIES",
                column: "MAP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MAP_HAS_ENTITIES_SAVED_GAME_ID",
                table: "MAP_HAS_ENTITIES",
                column: "SAVED_GAME_ID");

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
                name: "MAP_HAS_ENTITIES");

            migrationBuilder.DropTable(
                name: "ROUNDS");

            migrationBuilder.DropTable(
                name: "ENTITIES_BT");

            migrationBuilder.DropTable(
                name: "MAPS");

            migrationBuilder.DropTable(
                name: "SAVED_GAMES");
        }
    }
}
