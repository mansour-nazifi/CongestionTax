using CongestionTaxCalculator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace CongestionTaxCalculator.Infrastructure.Data.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(x => x.Name);

        builder.Property(t => t.Name).IsRequired();
        builder.Property(t => t.IsExempt).IsRequired();
    }
}
