using Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Infrastructure.Data.Configurations;

public class CountryConfiguration
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}
