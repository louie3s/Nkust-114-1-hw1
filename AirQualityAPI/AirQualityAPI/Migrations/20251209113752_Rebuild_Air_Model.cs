using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirQualityAPI.Migrations
{
    /// <inheritdoc />
    public partial class Rebuild_Air_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SiteId",
                table: "AirQuality",
                newName: "SiteID");

            migrationBuilder.RenameColumn(
                name: "Wind_Speed",
                table: "AirQuality",
                newName: "WindSpeed");

            migrationBuilder.RenameColumn(
                name: "Wind_Direc",
                table: "AirQuality",
                newName: "WindDirec");

            migrationBuilder.RenameColumn(
                name: "SO2_Avg",
                table: "AirQuality",
                newName: "SO2Avg");

            migrationBuilder.RenameColumn(
                name: "PM25_Avg",
                table: "AirQuality",
                newName: "PM25Avg");

            migrationBuilder.RenameColumn(
                name: "PM10_Avg",
                table: "AirQuality",
                newName: "PM10Avg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SiteID",
                table: "AirQuality",
                newName: "SiteId");

            migrationBuilder.RenameColumn(
                name: "WindSpeed",
                table: "AirQuality",
                newName: "Wind_Speed");

            migrationBuilder.RenameColumn(
                name: "WindDirec",
                table: "AirQuality",
                newName: "Wind_Direc");

            migrationBuilder.RenameColumn(
                name: "SO2Avg",
                table: "AirQuality",
                newName: "SO2_Avg");

            migrationBuilder.RenameColumn(
                name: "PM25Avg",
                table: "AirQuality",
                newName: "PM25_Avg");

            migrationBuilder.RenameColumn(
                name: "PM10Avg",
                table: "AirQuality",
                newName: "PM10_Avg");
        }
    }
}
