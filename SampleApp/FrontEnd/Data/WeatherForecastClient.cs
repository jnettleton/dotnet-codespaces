namespace FrontEnd.Data;

public record PagedResult<T>(int Total, int Page, int PageSize, T[] Items);

public class WeatherForecastClient
{
    private HttpClient _httpClient;
    private ILogger<WeatherForecastClient> _logger;

    public WeatherForecastClient(HttpClient httpClient, ILogger<WeatherForecastClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<PagedResult<WeatherForecast>> GetForecastAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<PagedResult<WeatherForecast>>(
               $"weatherforecast?page={page}&pageSize={pageSize}", cancellationToken)
           ?? new PagedResult<WeatherForecast>(0, page, pageSize, []);
}
