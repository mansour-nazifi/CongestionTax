using CongestionTaxCalculator.Application.Common.Interfaces;
using CongestionTaxCalculator.Domain.Entities;
using CongestionTaxCalculator.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IApplicationDbContext dbContext;

        public VehicleService(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Vehicle?> GetVehicle(string name)
        {
            return dbContext.Vehicles.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);
        }

        public Task<List<Vehicle>> GetVehicles()
        {
            return dbContext.Vehicles.AsNoTracking().ToListAsync();
        }
    }
}
