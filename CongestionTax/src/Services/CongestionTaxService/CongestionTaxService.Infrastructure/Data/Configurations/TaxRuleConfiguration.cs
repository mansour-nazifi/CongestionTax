using CongestionTaxService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace CongestionTaxService.Infrastructure.Data.Configurations;

public class TaxRuleConfiguration : IEntityTypeConfiguration<TaxRule>
{
    public void Configure(EntityTypeBuilder<TaxRule> builder)
    {
        builder.HasKey(x => x.City);
        builder.HasKey(x => x.StartTime);
        builder.HasKey(x => x.EndTime);

        builder.Property(t => t.City).IsRequired();
        builder.Property(t => t.StartTime).IsRequired();
        builder.Property(t => t.EndTime).IsRequired();
        builder.Property(t => t.Amount).IsRequired();
    }
}
