using Microsoft.Extensions.DependencyInjection.Services;

namespace Tests.Infrastructure.Services;

public class WeatherServiceTest
{
    [Fact]
    public void GetTemperatureTest()
    {
        // Arrange
        var sut = new WeatherService();

        // Act
        var ouptut = sut.GetTemperature("Portugal", DateTime.Now);

        // Assert
        Assert.InRange(ouptut, -10, 60);
    }
}
