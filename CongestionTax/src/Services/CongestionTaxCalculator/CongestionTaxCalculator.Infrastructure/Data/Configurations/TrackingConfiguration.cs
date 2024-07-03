using CongestionTaxCalculator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace CongestionTaxCalculator.Infrastructure.Data.Configurations;

public class TrackingConfiguration : IEntityTypeConfiguration<Tracking>
{
    public void Configure(EntityTypeBuilder<Tracking> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(t => t.CreateDate).IsRequired();
        builder.Property(t => t.VehicleId).IsRequired();
    }
}
