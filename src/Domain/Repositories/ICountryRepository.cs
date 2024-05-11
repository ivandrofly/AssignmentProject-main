namespace Assignment.Domain.Repositories;

public interface ICountryRepository
{
    Task<IList<Country>> Get();
}
