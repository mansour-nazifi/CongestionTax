using CongestionTaxService.Application.Common.Interfaces;
using CongestionTaxService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CongestionTaxService.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TaxRule> TaxRules => Set<TaxRule>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
