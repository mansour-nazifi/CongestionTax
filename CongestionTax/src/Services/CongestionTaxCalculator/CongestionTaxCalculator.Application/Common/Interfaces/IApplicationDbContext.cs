using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace CongestionTaxCalculator.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.Entities.Vehicle> Vehicles { get; }

    DbSet<Domain.Entities.Tracking> Tracings { get; }

    ChangeTracker ChangeTracker { get; }

    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

    int SaveChanges();
  
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
