# Artifacts

## Solution

**[SampleApp/SampleApp.sln](SampleApp/SampleApp.sln)** — .NET 10 solution containing two projects: BackEnd and FrontEnd.

---

## Projects

### BackEnd — [SampleApp/BackEnd/](SampleApp/BackEnd/)

ASP.NET Core minimal API that serves weather forecast data.

| File | Purpose |
|------|---------|
| [BackEnd.csproj](SampleApp/BackEnd/BackEnd.csproj) | Project file targeting `net10.0`; references `Microsoft.AspNetCore.OpenApi` and `Scalar.AspNetCore` |
| [Program.cs](SampleApp/BackEnd/Program.cs) | Entry point; registers OpenAPI, maps `/weatherforecast` GET endpoint, mounts Scalar UI at `/scalar` |
| [appsettings.json](SampleApp/BackEnd/appsettings.json) | Production configuration |
| [appsettings.Development.json](SampleApp/BackEnd/appsettings.Development.json) | Development overrides (enables Swagger/OpenAPI) |

**API endpoints**

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/weatherforecast` | Returns 5-day forecast (date, °C, °F, summary) |
| GET | `/scalar` | Interactive API docs (development only) |
| GET | `/openapi/v1.json` | OpenAPI document (development only) |

**Runtime port:** `8081`

---

### FrontEnd — [SampleApp/FrontEnd/](SampleApp/FrontEnd/)

Blazor Server app that calls the BackEnd API and displays weather data.

| File | Purpose |
|------|---------|
| [FrontEnd.csproj](SampleApp/FrontEnd/FrontEnd.csproj) | Project file targeting `net10.0` |
| [Program.cs](SampleApp/FrontEnd/Program.cs) | Entry point; registers Razor Pages, Blazor hub, and `WeatherForecastClient` (base URL from `WEATHER_URL` config) |
| [App.razor](SampleApp/FrontEnd/App.razor) | Root Blazor component |
| [_Imports.razor](SampleApp/FrontEnd/_Imports.razor) | Global `@using` directives |
| [Pages/_Host.cshtml](SampleApp/FrontEnd/Pages/_Host.cshtml) | Blazor Server host page |
| [Pages/FetchData.razor](SampleApp/FrontEnd/Pages/FetchData.razor) | Weather forecast display component |
| [Pages/Error.cshtml](SampleApp/FrontEnd/Pages/Error.cshtml) | Error page |
| [Data/WeatherForecast.cs](SampleApp/FrontEnd/Data/WeatherForecast.cs) | Model record (Date, TemperatureC, TemperatureF, Summary) |
| [Data/WeatherForecastClient.cs](SampleApp/FrontEnd/Data/WeatherForecastClient.cs) | Typed `HttpClient` that fetches from BackEnd `/weatherforecast` |
| [appsettings.json](SampleApp/FrontEnd/appsettings.json) | Production configuration; set `WEATHER_URL` here or via environment variable |
| [appsettings.Development.json](SampleApp/FrontEnd/appsettings.Development.json) | Development overrides |

**Runtime port:** `8080`

**Required configuration:** `WEATHER_URL` — base URL of the BackEnd service (e.g. `https://localhost:8081`).

---

## Images

Reference screenshots used in [readme.md](readme.md).

| File | Shows |
|------|-------|
| [images/RunAll.png](images/RunAll.png) | VS Code debug menu — "Run All" |
| [images/BlazorApp.png](images/BlazorApp.png) | FrontEnd weather display |
| [images/scalar.png](images/scalar.png) | Scalar interactive API docs |
| [images/StopRun.png](images/StopRun.png) | VS Code stop debug toolbar |
