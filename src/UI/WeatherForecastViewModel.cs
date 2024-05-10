using Assignment.Application.Common.Interfaces;
using Assignment.Domain.Entities;
using Caliburn.Micro;
using MediatR;
using Microsoft.Extensions.DependencyInjection.Countries;

namespace Assignment.UI.ViewModels;

/// <summary>
/// Represents a view model for the weather forecast.
/// </summary>
public class WeatherForecastViewModel : Screen
{
    private readonly IWindowManager _windowManager;
    private readonly ISender _sender;
    private readonly IWeatherForecastApi _weatherForecastApi;
    private IList<CountryDto> _countries;
    private CountryDto _selectedCountry;
    private CityDto _selectedCity;
    private int _temperatureAtGivenTime;

    /// <summary>
    /// Represents a list of countries.
    /// </summary>
    public IList<CountryDto> Countries
    {
        get => _countries;
        set
        {
            if (Equals(value, _countries))
            {
                return;
            }

            _countries = value;
            NotifyOfPropertyChange();
        }
    }

    /// <summary>
    /// Represents the selected country in the WeatherForecastViewModel.
    /// </summary>
    public CountryDto SelectedCountry
    {
        get => _selectedCountry;
        set
        {
            if (Equals(value, _selectedCountry))
            {
                return;
            }

            _selectedCountry = value;
            NotifyOfPropertyChange();
        }
    }

    /// <summary>
    /// Represents the selected city in the WeatherForecastViewModel.
    /// </summary>
    public CityDto SelectedCity
    {
        get => _selectedCity;
        set
        {
            if (Equals(value, _selectedCity))
            {
                return;
            }

            _selectedCity = value;
            NotifyOfPropertyChange();
            
            RefreshData();
        }
    }

    /// <summary>
    /// Refreshes the data by retrieving the temperature for the selected city at the current time.
    /// </summary>
    /// <remarks>
    /// This method makes use of the <see cref="IWeatherForecastApi"/> to get the temperature.
    /// If a city is selected, the temperature for that city at the current time is retrieved and assigned to the <see cref="TemperatureAtGivenTime"/> property.
    /// </remarks>
    private void RefreshData()
    {
        if (SelectedCity is not null)
        {
            TemperatureAtGivenTime = _weatherForecastApi.GetTemperature(_selectedCity.Name, DateTime.Now);
        }
    }

    /// <summary>
    /// Represents the temperature for a given time in a selected city.
    /// </summary>
    public int TemperatureAtGivenTime
    {
        get => _temperatureAtGivenTime;
        set
        {
            if (value == _temperatureAtGivenTime)
            {
                return;
            }

            _temperatureAtGivenTime = value;
            NotifyOfPropertyChange();
        }
    }

    public WeatherForecastViewModel(IWindowManager windowManager,
        ISender sender, IWeatherForecastApi weatherForecastApi)
    {
        _windowManager = windowManager;
        _sender = sender;
        _weatherForecastApi = weatherForecastApi;
        InitializeComboboxAsync();
    }

    /// <summary>
    /// Initializes the combobox by populating it with a list of countries.
    /// </summary>
    public async void InitializeComboboxAsync()
    {
        Countries = await _sender.Send(new CountryQuery());
    }
}
