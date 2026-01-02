using System.Text.Json;
using AirQualityAPI.Models;
public static class DataImport
{
    public static void Import(AppDbContext db)
    {
        if (!db.AirQuality.Any()) // 避免重複寫入
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "pm25.json");

            var json = File.ReadAllText(path);
            var root = JsonSerializer.Deserialize<Root>(json);

            db.AirQuality.AddRange(root.records);
            try
            {
                db.SaveChanges();                                
            }
            catch (Exception ex)
            {
                Console.WriteLine("================ ERROR FOUND ================");
                Console.WriteLine(ex.InnerException?.Message);
                Console.WriteLine("============================================");
                throw;
            }

        }
    }
}

public class Root
{
    public List<AirQuality> records { get; set; }
}
