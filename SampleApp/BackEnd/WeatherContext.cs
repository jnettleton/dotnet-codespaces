using Microsoft.EntityFrameworkCore;

namespace BackEnd;

public class WeatherContext(DbContextOptions<WeatherContext> options) : DbContext(options)
{
    public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherForecast>().HasKey(w => w.Id);
    }
}
