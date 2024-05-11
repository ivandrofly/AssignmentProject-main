using Assignment.Application.Common.Interfaces;
using Assignment.Domain.Entities;
using Assignment.Domain.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Countries;

namespace Microsoft.Extensions.DependencyInjection.Repositories;

/// <summary>
/// Represents a repository for managing country data.
/// </summary>
public class CountryRepository : ICountryRepository
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CountryRepository(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves a list of countries from the repository.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the list of countries.
    /// </returns>
    public async Task<IList<Country>> Get()
    {
        return await _context.Countries
            .Include(c => c.Cities)
            .AsNoTracking().ToListAsync();
    }
}

// Note: using repository pattern will make it easier for the mocking framwork mock the repositories
// as showing in CountryQueryHandlerTest.cs
