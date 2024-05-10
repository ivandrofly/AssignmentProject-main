using Assignment.Application.Common.Interfaces;
using Assignment.Domain.Entities;
using Caliburn.Micro;
using MediatR;
using Microsoft.Extensions.DependencyInjection.Countries;

namespace Assignment.UI.ViewModels;

public class WeatherForecastViewModel : Screen
{
    private readonly IWindowManager _windowManager;
    private readonly ISender _sender;
    private readonly IWeatherForecastApi _weatherForecastApi;
    private IList<Country> _countries;
    private Country _selectedCountry;
    private City _selectedCity;
    private int _temperatureAtGivenTime;

    public IList<Country> Countries
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

    public Country SelectedCountry
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

    public City SelectedCity
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

            // fetch the data from weather-service
            TemperatureAtGivenTime = _weatherForecastApi.GetTemperature(_selectedCity.Name, DateTime.Now);
        }
    }

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
        // InitializeComboboxAsync();
    }

    public async Task InitializeComboboxAsync()
    {
        Countries = new List<Country>()
        {
            new Country() { Name = "Portutgal", Cities = new List<City>() { new City() { Name = "Lisbon" } } }
        };
        await _sender.Send(new CountryQuery());
    }
}
