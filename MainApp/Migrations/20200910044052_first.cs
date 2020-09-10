using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MainApp.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    AirportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportRef = table.Column<int>(nullable: false),
                    AirportName = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.AirportId);
                });

            migrationBuilder.CreateTable(
                name: "Runways",
                columns: table => new
                {
                    RunwayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportId = table.Column<int>(nullable: false),
                    RunwayName = table.Column<string>(nullable: true),
                    RunwayMaterial = table.Column<string>(nullable: true),
                    RunwayLengthFt = table.Column<int>(nullable: false),
                    LowHeadingDeg = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runways", x => x.RunwayId);
                    table.ForeignKey(
                        name: "FK_Runways_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "AirportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    WeatherForecastId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportId = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.WeatherForecastId);
                    table.ForeignKey(
                        name: "FK_WeatherForecasts_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "AirportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeatherReports",
                columns: table => new
                {
                    WeatherReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WindDirectionDeg = table.Column<int>(nullable: false),
                    WindSpeed = table.Column<double>(nullable: false),
                    PredictionDatetime = table.Column<DateTime>(nullable: false),
                    WeatherForecastId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherReports", x => x.WeatherReportId);
                    table.ForeignKey(
                        name: "FK_WeatherReports_WeatherForecasts_WeatherForecastId",
                        column: x => x.WeatherForecastId,
                        principalTable: "WeatherForecasts",
                        principalColumn: "WeatherForecastId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Runways_AirportId",
                table: "Runways",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_AirportId",
                table: "WeatherForecasts",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherReports_WeatherForecastId",
                table: "WeatherReports",
                column: "WeatherForecastId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Runways");

            migrationBuilder.DropTable(
                name: "WeatherReports");

            migrationBuilder.DropTable(
                name: "WeatherForecasts");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
