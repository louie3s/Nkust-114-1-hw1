using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirQualityAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAirQualitySchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SiteName",
                table: "AirQuality",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "PM25Avg",
                table: "AirQuality",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PM25",
                table: "AirQuality",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "County",
                table: "AirQuality",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "AQI",
                table: "AirQuality",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CO",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NO2",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "O3",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "O3_8hr",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PM10",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PM10Avg",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublishTime",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SO2",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CO",
                table: "AirQuality");

            migrationBuilder.DropColumn(
                name: "NO2",
                table: "AirQuality");

            migrationBuilder.DropColumn(
                name: "O3",
                table: "AirQuality");

            migrationBuilder.DropColumn(
                name: "O3_8hr",
                table: "AirQuality");

            migrationBuilder.DropColumn(
                name: "PM10",
                table: "AirQuality");

            migrationBuilder.DropColumn(
                name: "PM10Avg",
                table: "AirQuality");

            migrationBuilder.DropColumn(
                name: "PublishTime",
                table: "AirQuality");

            migrationBuilder.DropColumn(
                name: "SO2",
                table: "AirQuality");

            migrationBuilder.AlterColumn<string>(
                name: "SiteName",
                table: "AirQuality",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PM25Avg",
                table: "AirQuality",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PM25",
                table: "AirQuality",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "County",
                table: "AirQuality",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AQI",
                table: "AirQuality",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
