using CongestionTaxCalculator.Application.Common.Interfaces;
using CongestionTaxCalculator.Domain.Entities;
using CongestionTaxCalculator.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.Application.Services
{
    public class TrackingService : ITrackingService
    {
        private readonly IApplicationDbContext dbContext;

        public TrackingService(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<List<Tracking>> GetTracings(Vehicle vehicle, string city)
        {
            return dbContext.Tracings.AsNoTracking()
                .Include(x => x.Vehicle)
                .Where(x => x.VehicleId == vehicle.Name & x.City == city)
                .OrderBy(x => x.CreateDate)
                .ToListAsync();
        }
    }
}
