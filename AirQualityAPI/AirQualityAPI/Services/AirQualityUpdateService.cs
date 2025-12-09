/*using System.Net.Http.Json;
using System.Text.Json;
using AirQualityAPI.Models;

public class AirQualityUpdateService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly HttpClient _http = new();

    public AirQualityUpdateService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await UpdateAirData();          // ⭐ 執行更新
            await Task.Delay(TimeSpan.FromDays(1), stoppingToken); // ⭐ 每天執行一次
        }
    }

    private async Task UpdateAirData()
    {
        try
        {
            string url = "https://data.epa.gov.tw/api/v2/aqx_p_432?limit=200&format=JSON";
            var json = await _http.GetStringAsync(url);

            var root = JsonSerializer.Deserialize<Root>(json);

            using var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            db.AirQuality.RemoveRange(db.AirQuality);  // 清除舊資料 (避免重複)
            db.AirQuality.AddRange(root.records);      // 寫入資料庫
            await db.SaveChangesAsync();

            Console.WriteLine($"✔ 資料更新成功 {DateTime.Now}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ 更新資料失敗：{ex.Message}");
        }
    }
}*/

