namespace Assignment.Domain.Entities;

public class Country : BaseAuditableEntity
{
    public string? Name { get; set; }
    public List<City> Cities { get; set; } = new();
}
