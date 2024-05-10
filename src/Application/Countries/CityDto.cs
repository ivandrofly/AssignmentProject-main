using Assignment.Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.Countries;

public class CityDto
{
    public string? Name { get; set; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<City, CityDto>();
        }
    }
}
