using Assignment.Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.Countries;

public class CountryDto
{
    public string? Name { get; set; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Country, CountryDto>();
        }
    }
}
