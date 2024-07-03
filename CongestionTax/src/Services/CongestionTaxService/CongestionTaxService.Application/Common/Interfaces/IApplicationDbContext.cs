using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace CongestionTaxService.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.Entities.TaxRule> TaxRules { get; }

    ChangeTracker ChangeTracker { get; }

    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

    int SaveChanges();
  
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
