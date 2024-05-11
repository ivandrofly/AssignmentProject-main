using Assignment.Application.Common.Interfaces;

namespace Microsoft.Extensions.DependencyInjection.Services;

/// <summary>
/// Represents a weather service that provides weather forecast data.
/// </summary>
public class WeatherService : IWeatherForecastApi
{
    /// <summary>
    /// Retrieves the temperature for a given city at a specific time.
    /// </summary>
    /// <param name="cityName">The name of the city.</param>
    /// <param name="time">The specific time for which to retrieve the temperature.</param>
    /// <returns>The temperature of the given city at the specified time.</returns>
    public int GetTemperature(string cityName, DateTime time)
    {
        return Random.Shared.Next(-10, 60);
    }
}
