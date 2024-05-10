using Assignment.Application.Common.Interfaces;

namespace Microsoft.Extensions.DependencyInjection.Services;

public class WeatherService : IWeatherForecastApi
{
    public int GetTemperature(string cityName, DateTime time)
    {
        return Random.Shared.Next(-10, 60);
    }
}
