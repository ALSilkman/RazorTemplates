using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RazorTemplates.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryFlag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_Countries_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { "archery", "Archery/Indoor" },
                    { "bobsleigh", "Bobsleigh/Outdoor" },
                    { "breakdancing", "Breakdancing/Indoor" },
                    { "canoe", "Canoe Sprint/Outdoor" },
                    { "curling", "Curling/Indoor" },
                    { "cycling", "Road Cycling/Outdoor" },
                    { "diving", "Diving/Indoor" },
                    { "skateboarding", "Skateboarding/Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "GameName" },
                values: new object[,]
                {
                    { "para", "Paralymics" },
                    { "sum", "Summer Olympics" },
                    { "win", "Winter Olympics" },
                    { "youth", "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CategoryId", "CountryFlag", "CountryName", "GameId" },
                values: new object[,]
                {
                    { "aus", "canoe", "AUS.png", "Austria", "para" },
                    { "bra", "cycling", "BRA.png", "Brazil", "sum" },
                    { "bri", "curling", "BRI.png", "Great Britain", "win" },
                    { "can", "curling", "CAN.png", "Canada", "win" },
                    { "chi", "diving", "CHI.png", "China", "sum" },
                    { "cyp", "breakdancing", "CYP.png", "Cyprus", "youth" },
                    { "fin", "skateboarding", "FIN.png", "Finland", "youth" },
                    { "fra", "breakdancing", "FRA.png", "France", "youth" },
                    { "ger", "diving", "GER.png", "Germany", "sum" },
                    { "ita", "bobsleigh", "ITA.png", "Italy", "win" },
                    { "jam", "bobsleigh", "JAM.png", "Jamaica", "win" },
                    { "jap", "bobsleigh", "JAP.png", "Japan", "win" },
                    { "mex", "diving", "MEX.png", "Mexico", "sum" },
                    { "net", "cycling", "NET.png", "Netherlands", "sum" },
                    { "pak", "canoe", "PAK.png", "Pakistan", "para" },
                    { "por", "skateboarding", "POR.png", "Portugal", "youth" },
                    { "rus", "breakdancing", "RUS.png", "Russia", "youth" },
                    { "slo", "skateboarding", "SLO.png", "Slovakia", "youth" },
                    { "swe", "curling", "SWE.png", "Sweden", "win" },
                    { "tha", "archery", "THA.png", "Thailand", "para" },
                    { "ukr", "archery", "UKR.png", "Ukraine", "para" },
                    { "uru", "archery", "URU.png", "Uruguay", "para" },
                    { "usa", "cycling", "USA.png", "USA", "sum" },
                    { "zim", "canoe", "ZIM.png", "Zimbabwe", "para" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CategoryId",
                table: "Countries",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameId",
                table: "Countries",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
