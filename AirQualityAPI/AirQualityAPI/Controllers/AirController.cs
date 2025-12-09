using Microsoft.AspNetCore.Mvc;
using AirQualityAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class AirController : ControllerBase
{
    private readonly AppDbContext _db;

    public AirController(AppDbContext db)
    {
        _db = db;
    }

    // 🔥 取得所有資料
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_db.AirQuality.ToList());
    }

    // 🔥 查詢縣市
    [HttpGet("{city}")]
    public IActionResult GetByCity(string city)
    {
        var result = _db.AirQuality
                        .Where(x => x.County.Contains(city))
                        .ToList();

        if (!result.Any()) return NotFound("找不到該縣市資料");
        return Ok(result);
    }

    // 🔥 PM2.5 污染排行 TOP10
    [HttpGet("top/{count}")]
    public IActionResult TopWorst(int count)
    {
        var result = _db.AirQuality
                        .Where(x => x.PM25 != null && x.PM25 != "-")
                        .OrderByDescending(x => Convert.ToInt32(x.PM25))
                        .Take(count)
                        .ToList();

        return Ok(result);
    }
}
