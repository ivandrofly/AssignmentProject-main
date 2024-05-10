using Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Infrastructure.Data.Configurations;

public class CityConfiguration
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}
