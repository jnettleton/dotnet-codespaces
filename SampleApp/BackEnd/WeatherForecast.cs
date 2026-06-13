using System.ComponentModel.DataAnnotations;

namespace BackEnd;

public class WeatherForecast
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }

    [Range(-60, 60, ErrorMessage = "Temperature must be between -60°C and 60°C.")]
    public int TemperatureC { get; set; }

    [MaxLength(100)]
    public string? Summary { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
