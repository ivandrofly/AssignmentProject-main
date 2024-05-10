using Caliburn.Micro;

namespace Assignment.UI.ViewModels;

public class WeatherForecastViewModel : Screen
{
    private readonly IWindowManager _windowManager;

    public WeatherForecastViewModel(IWindowManager windowManager)
    {
        _windowManager = windowManager;
    }
}
