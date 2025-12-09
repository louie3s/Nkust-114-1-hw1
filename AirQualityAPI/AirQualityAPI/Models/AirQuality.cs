namespace AirQualityAPI.Models
{
    public class AirQuality
    {
        public int Id { get; set; }
        public string? SiteName { get; set; }
        public string? County { get; set; }
        public string? AQI { get; set; }
        public string? Status { get; set; }
        public string? PM25 { get; set; }
        public string? PM25Avg { get; set; }
        public string? PM10 { get; set; }
        public string? PM10Avg { get; set; }
        public string? O3 { get; set; }
        public string? O3_8hr { get; set; }
        public string? NO2 { get; set; }
        public string? SO2 { get; set; }
        public string? CO { get; set; }
        public string? PublishTime { get; set; }
    }
}
