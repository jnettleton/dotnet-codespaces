using Microsoft.EntityFrameworkCore;

namespace BackEnd;

public class WeatherContext(DbContextOptions<WeatherContext> options) : DbContext(options)
{
    public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherForecast>().HasKey(w => w.Id);

        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        var startDate = new DateOnly(2025, 1, 1);

        var seedData = Enumerable.Range(1, 30).Select(i => new WeatherForecast
        {
            Id = i,
            Date = startDate.AddDays(i - 1),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[i % summaries.Length]
        }).ToArray();

        modelBuilder.Entity<WeatherForecast>().HasData(seedData);
    }
}
