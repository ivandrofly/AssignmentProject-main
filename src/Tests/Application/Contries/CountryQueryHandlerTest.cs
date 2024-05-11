using System.Collections;
using System.Data;
using System.Linq.Expressions;
using Assignment.Application.Common.Interfaces;
using Assignment.Domain.Entities;
using Assignment.Domain.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Countries;
using NSubstitute;
using NSubstitute.Extensions;

namespace Tests.Application.Contries;

public class CountryQueryHandlerTest
{
    [Fact]
    public async Task HandleTest()
    {
        // Arrange
        var countryRepository = NSubstitute.Substitute.For<ICountryRepository>();
        countryRepository.Configure().Get().Returns(new List<Country>()
        {
            new() { Name = "Guinea-Bissau", Cities = new List<City>() { new() { Name = "Bissau" } } },
            new() { Name = "Portugal", Cities = new List<City>() { new() { Name = "Lisbon" } } },
        });

        var mapper = new Mapper(new MapperConfiguration(configure =>
        {
            configure.CreateMap<Country, CountryDto>();
            configure.CreateMap<City, CityDto>();
        }));

        var countryQueryHandler = new CountryQueryHandler(countryRepository, mapper);

        // Act
        var response = await countryQueryHandler.Handle(new CountryQuery(), CancellationToken.None);

        // Assert
        Assert.Equal(2, response.Count);
    }
}

// Note: The Added this test to show `CountryQueryHandler` can be tested easly :)
// be aware that we are using the repositories to communicate with the data persistance instead of using `IApplicationDbContext`
