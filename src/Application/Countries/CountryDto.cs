using Assignment.Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.Countries;

public class CountryDto
{
    public string? Name { get; set; }

    public IList<CityDto> Cities { get; set; } = Array.Empty<CityDto>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Country, CountryDto>();
        }
    }
}
