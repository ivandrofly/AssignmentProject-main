using Assignment.Application.Common.Interfaces;
using Assignment.Application.Common.Security;
using Assignment.Application.TodoLists.Queries.GetTodos;
using Assignment.Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.Countries;

[Authorize]
public record CountryQuery : IRequest<IList<CountryDto>>;

public class CountryQueryHandler : IRequestHandler<CountryQuery, IList<CountryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CountryQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IList<CountryDto>> Handle(CountryQuery request, CancellationToken cancellationToken)
    {
        return await _context.Countries
            .AsNoTracking()
            .ProjectTo<CountryDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Name)
            .ToListAsync(cancellationToken);
    }
}
