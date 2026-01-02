using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AirQualityAPI.Models
{
    public class AirQuality
    {
        public int Id { get; set; }

        [JsonPropertyName("sitename")]
        public string? SiteName { get; set; }

        [JsonPropertyName("county")]
        public string? County { get; set; }

        [JsonPropertyName("aqi")]
        public string? AQI { get; set; }

        [JsonPropertyName("pollutant")]
        public string? Pollutant { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("so2")]
        public string? SO2 { get; set; }

        [JsonPropertyName("co")]
        public string? CO { get; set; }

        [JsonPropertyName("o3")]
        public string? O3 { get; set; }

        [JsonPropertyName("o3_8hr")]
        public string? O3_8hr { get; set; }

        [JsonPropertyName("pm10")]
        public string? PM10 { get; set; }

        [JsonPropertyName("pm2.5")]
        public string? PM25 { get; set; }  // 🔥 已對應成功的欄位

        [JsonPropertyName("no2")]
        public string? NO2 { get; set; }

        [JsonPropertyName("nox")]
        public string? NOX { get; set; }

        [JsonPropertyName("no")]
        public string? NO { get; set; }

        [JsonPropertyName("wind_speed")]
        public string? WindSpeed { get; set; }

        [JsonPropertyName("wind_direc")]
        public string? WindDirec { get; set; }

        [JsonPropertyName("publishtime")]
        public string? PublishTime { get; set; }

        [JsonPropertyName("co_8hr")]
        public string? CO_8hr { get; set; }

        [JsonPropertyName("pm2.5_avg")]
        public string? PM25Avg { get; set; }

        [JsonPropertyName("pm10_avg")]
        public string? PM10Avg { get; set; }

        [JsonPropertyName("so2_avg")]
        public string? SO2Avg { get; set; }

        [JsonPropertyName("longitude")]
        public string? Longitude { get; set; }

        [JsonPropertyName("latitude")]
        public string? Latitude { get; set; }

        [JsonPropertyName("siteid")]
        public string? SiteID { get; set; }

        // 🔥 計算用欄位（不存進資料庫）
        [NotMapped]
        public int PM25Int
        {
            get
            {
                return int.TryParse(PM25, out var v) ? v : 0;
            }
        }
    }
}
