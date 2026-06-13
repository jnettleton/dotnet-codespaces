# Artifacts

## Solution

**[SampleApp/SampleApp.sln](SampleApp/SampleApp.sln)** — .NET 10 solution containing two projects: BackEnd and FrontEnd.

---

## Projects

### BackEnd — [SampleApp/BackEnd/](SampleApp/BackEnd/)

ASP.NET Core minimal API that serves paginated weather forecast data from Azure SQL via Entity Framework Core.

| File | Purpose |
|------|---------|
| [BackEnd.csproj](SampleApp/BackEnd/BackEnd.csproj) | Project file targeting `net10.0`; references `Microsoft.AspNetCore.OpenApi`, `Scalar.AspNetCore`, `Microsoft.EntityFrameworkCore.SqlServer`, and `Microsoft.EntityFrameworkCore.Design` |
| [Program.cs](SampleApp/BackEnd/Program.cs) | Entry point; configures CORS (`FrontEnd` policy), OpenAPI, EF Core (`WeatherContext`), DB seeding on startup, and maps the `/weatherforecast` paginated GET endpoint |
| [WeatherContext.cs](SampleApp/BackEnd/WeatherContext.cs) | EF Core `DbContext`; defines `WeatherForecasts` `DbSet` and seeds 30 records starting 2025-01-01 |
| [WeatherForecast.cs](SampleApp/BackEnd/WeatherForecast.cs) | EF entity with `Id`, `Date`, `TemperatureC` (validated -60–60°C), `Summary` (max 100 chars), and computed `TemperatureF` |
| [appsettings.json](SampleApp/BackEnd/appsettings.json) | Production config; set `ConnectionStrings:AzureSql` and `AllowedOrigins` array here |
| [appsettings.Development.json](SampleApp/BackEnd/appsettings.Development.json) | Development overrides (enables Swagger/OpenAPI) |

**API endpoints**

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/weatherforecast?page=1&pageSize=10` | Returns paginated forecast: `{ total, page, pageSize, items[] }` |
| GET | `/scalar` | Interactive API docs (development only) |
| GET | `/openapi/v1.json` | OpenAPI document (development only) |

**Required configuration:** `ConnectionStrings:AzureSql` — connection string for Azure SQL Database.

**CORS:** In development, allows any origin. In production, restricts to origins listed in `AllowedOrigins`.

**Runtime port:** `8081`

---

### FrontEnd — [SampleApp/FrontEnd/](SampleApp/FrontEnd/)

Blazor Server app that calls the BackEnd API and displays paginated weather data.

| File | Purpose |
|------|---------|
| [FrontEnd.csproj](SampleApp/FrontEnd/FrontEnd.csproj) | Project file targeting `net10.0`; references `Microsoft.Extensions.Http.Resilience` |
| [Program.cs](SampleApp/FrontEnd/Program.cs) | Entry point; registers Razor Pages, Blazor hub, and `WeatherForecastClient` with resilience handler (base URL from `WEATHER_URL` — throws if not set) |
| [App.razor](SampleApp/FrontEnd/App.razor) | Root Blazor component |
| [_Imports.razor](SampleApp/FrontEnd/_Imports.razor) | Global `@using` directives |
| [Pages/_Host.cshtml](SampleApp/FrontEnd/Pages/_Host.cshtml) | Blazor Server host page |
| [Pages/FetchData.razor](SampleApp/FrontEnd/Pages/FetchData.razor) | Weather forecast display with pagination controls (previous/next/page buttons) and loading/error states |
| [Pages/Error.cshtml](SampleApp/FrontEnd/Pages/Error.cshtml) | Error page |
| [Data/WeatherForecast.cs](SampleApp/FrontEnd/Data/WeatherForecast.cs) | Model record (`Id`, `Date`, `TemperatureC`, `TemperatureF`, `Summary`) |
| [Data/WeatherForecastClient.cs](SampleApp/FrontEnd/Data/WeatherForecastClient.cs) | Typed `HttpClient`; `GetForecastAsync(page, pageSize)` returns `PagedResult<WeatherForecast>` |
| [appsettings.json](SampleApp/FrontEnd/appsettings.json) | Production configuration; set `WEATHER_URL` here or via environment variable |
| [appsettings.Development.json](SampleApp/FrontEnd/appsettings.Development.json) | Development overrides |

**Runtime port:** `8080`

**Required configuration:** `WEATHER_URL` — base URL of the BackEnd service (e.g. `https://localhost:8081`). Startup throws if missing.

---

## Images

Reference screenshots used in [readme.md](readme.md).

| File | Shows |
|------|-------|
| [images/RunAll.png](images/RunAll.png) | VS Code debug menu — "Run All" |
| [images/BlazorApp.png](images/BlazorApp.png) | FrontEnd weather display |
| [images/scalar.png](images/scalar.png) | Scalar interactive API docs |
| [images/StopRun.png](images/StopRun.png) | VS Code stop debug toolbar |
