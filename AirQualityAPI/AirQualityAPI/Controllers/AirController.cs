using Microsoft.AspNetCore.Mvc;
using AirQualityAPI.Models;
using System.Globalization;

[Route("api/[controller]")]
[ApiController]
public class AirController : ControllerBase
{
    private readonly AppDbContext _db;

    public AirController(AppDbContext db) => _db = db;

    // helper: 安全解析 int，不能解析回傳 null
    private int? ParseIntSafe(string? s)
    {
        if (string.IsNullOrWhiteSpace(s)) return null;
        // 去掉非數字的符號 (有需要可更複雜)
        s = s.Trim();
        return int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v) ? v : null;
    }

    // 取得所有資料 (限制回傳量避免一次倒大量資料)
    [HttpGet]
    public IActionResult GetAll(int limit = 1000)
    {
        try
        {
            var q = _db.AirQuality.Take(limit).ToList();
            return Ok(q);
        }
        catch (Exception ex)
        {
            // 可換成 logger.LogError(ex, "GetAll failed");
            return Problem(detail: ex.InnerException?.Message ?? ex.Message, title: "Server error");
        }
    }

    // 查詢縣市 (包含模糊、大小寫不敏感)
    // 查詢縣市（精確比對，避免 SQLite 中文問題）
    [HttpGet("{city}")]
    public IActionResult GetByCity(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
            return BadRequest("city 不能為空");

        var name = city.Trim();

        var result = _db.AirQuality
            .Where(x => x.County != null && x.County.Trim() == name)
            .AsEnumerable()
            .OrderByDescending(x => x.PM25Int)
            .ToList();

        if (!result.Any())
            return NotFound($"找不到縣市：{name}");

        return Ok(result);
    }


    // PM2.5 污染排行 TOP N (安全解析 PM25，會忽略無法解析的記錄)
    [HttpGet("top/{count}")]
    public IActionResult TopWorst(int count = 10)
    {
        try
        {
            if (count <= 0) return BadRequest("count 必須 > 0");

            // 先把資料拉回記憶體再處理解析與排序（避免 EF Core 無法翻譯解析邏輯）
            var all = _db.AirQuality.AsEnumerable();

            var parsed = all
                .Select(x => new
                {
                    Record = x,
                    PM25Int = ParseIntSafe(x.PM25)
                })
                // 只保留可以解析為數字的
                .Where(t => t.PM25Int.HasValue)
                .OrderByDescending(t => t.PM25Int.Value)
                .Take(count)
                .Select(t => new
                {
                    t.Record.SiteName,
                    t.Record.County,
                    PM25 = t.Record.PM25,
                    PM25Int = t.PM25Int,
                    t.Record.AQI,
                    t.Record.PublishTime
                })
                .ToList();

            return Ok(parsed);
        }
        catch (Exception ex)
        {
            return Problem(detail: ex.InnerException?.Message ?? ex.Message, title: "Server error");
        }
    }
}
