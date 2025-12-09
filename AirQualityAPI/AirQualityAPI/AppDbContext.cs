using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AirQualityAPI.Models;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<AirQuality> AirQuality { get; set; }
}
