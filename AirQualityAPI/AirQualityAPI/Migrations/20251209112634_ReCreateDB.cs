using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirQualityAPI.Migrations
{
    /// <inheritdoc />
    public partial class ReCreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "AirQuality",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AirQuality");
        }
    }
}
