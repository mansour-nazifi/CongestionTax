using CongestionTaxCalculator.Application.Common.Interfaces;
using CongestionTaxCalculator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CongestionTaxCalculator.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    public DbSet<Tracking> Tracings => Set<Tracking>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
