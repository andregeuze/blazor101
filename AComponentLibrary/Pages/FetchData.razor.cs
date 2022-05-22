using AComponentLibrary.Data;
using Microsoft.AspNetCore.Components;

namespace AComponentLibrary.Pages;

public partial class FetchData
{
    [Inject] private IWeatherForecastService? WeatherForecastService { get; set; }

    private WeatherForecast[]? forecasts;
    protected override async Task OnInitializedAsync()
    {
        if (WeatherForecastService == null) return;

        forecasts = await WeatherForecastService.GetForecastAsync(DateTime.Now);
    }
}