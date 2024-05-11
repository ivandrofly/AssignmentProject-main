using Assignment.Application.Common.Interfaces;
using Assignment.Application.Common.Security;
using Assignment.Application.TodoLists.Queries.GetTodos;
using Assignment.Domain.Entities;
using Assignment.Domain.Repositories;

namespace Microsoft.Extensions.DependencyInjection.Countries;

[Authorize]
public record CountryQuery : IRequest<IList<CountryDto>>;

public class CountryQueryHandler : IRequestHandler<CountryQuery, IList<CountryDto>>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public CountryQueryHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    public async Task<IList<CountryDto>> Handle(CountryQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<IList<Country>, IList<CountryDto>>(await _countryRepository.Get())
            .OrderBy(c => c.Name).ToList();
    }
}


// Note: using repository pattern will make it easier for the mocking framwork mock the repositories
