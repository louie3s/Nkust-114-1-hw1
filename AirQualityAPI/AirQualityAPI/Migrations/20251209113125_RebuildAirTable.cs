using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirQualityAPI.Migrations
{
    /// <inheritdoc />
    public partial class RebuildAirTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PM25Avg",
                table: "AirQuality",
                newName: "Wind_Speed");

            migrationBuilder.RenameColumn(
                name: "PM10Avg",
                table: "AirQuality",
                newName: "Wind_Direc");

            migrationBuilder.AddColumn<string>(
                name: "CO_8hr",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NO",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NOX",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PM10_Avg",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PM25_Avg",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pollutant",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SO2_Avg",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteId",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CO_8hr",
                table: "AirQuality");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "AirQuality");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "AirQuality");

            migrationBuilder.DropColumn(
                name: "NO",
                table: "AirQuality");

            migrationBuilder.DropColumn(
                name: "NOX",
                table: "AirQuality");

            migrationBuilder.DropColumn(
                name: "PM10_Avg",
                table: "AirQuality");

            migrationBuilder.DropColumn(
                name: "PM25_Avg",
                table: "AirQuality");

            migrationBuilder.DropColumn(
                name: "Pollutant",
                table: "AirQuality");

            migrationBuilder.DropColumn(
                name: "SO2_Avg",
                table: "AirQuality");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "AirQuality");

            migrationBuilder.RenameColumn(
                name: "Wind_Speed",
                table: "AirQuality",
                newName: "PM25Avg");

            migrationBuilder.RenameColumn(
                name: "Wind_Direc",
                table: "AirQuality",
                newName: "PM10Avg");
        }
    }
}
