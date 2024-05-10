using Assignment.Application.Common.Interfaces;

namespace Microsoft.Extensions.DependencyInjection.Services;

public class WeatherService : IWeatherForecastApi
{
    public int GetTemperature(string cityName, DateTime time)
    {
        throw new NotImplementedException();
    }
}
