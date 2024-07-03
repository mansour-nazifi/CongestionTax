using CongestionTaxCalculator.Application.Common.Interfaces;
using CongestionTaxCalculator.Domain.Entities;

namespace CongestionTaxCalculator.Infrastructure.Data;
public class ApplicationDbContextInitialiser
{
    private readonly IApplicationDbContext _context;

    public ApplicationDbContextInitialiser(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        var busses = "Busses";
        var taxi = "Taxi";

        var gothenburg = nameof(CongestionTaxCity.Cities.Gothenburg);

        if (!_context.Vehicles.Any())
        {
            _context.Vehicles.Add(new Vehicle
            {
                Name = taxi,
                IsExempt = false
            });

            _context.Vehicles.Add(new Vehicle
            {
                Name = "Emergency vehicles",
                IsExempt = true
            });

            _context.Vehicles.Add(new Vehicle
            {
                Name = busses,
                IsExempt = true
            });

            _context.Vehicles.Add(new Vehicle
            {
                Name = "Diplomat vehicles",
                IsExempt = true
            });

            _context.Vehicles.Add(new Vehicle
            {
                Name = "Motorcycles",
                IsExempt = true
            });

            _context.Vehicles.Add(new Vehicle
            {
                Name = "Military vehicles",
                IsExempt = true
            });

            _context.Vehicles.Add(new Vehicle
            {
                Name = "Foreign vehicles",
                IsExempt = true
            });

            await _context.SaveChangesAsync();
        }

        if (!_context.Tracings.Any())
        {
            #region Taxi           
            _context.Tracings.Add(new Tracking
            {
                Id = 1,
                CreateDate = new DateTime(2013, 1, 14, 21, 0, 0),
                VehicleId = taxi,
                City = gothenburg
            });

            _context.Tracings.Add(new Tracking
            {
                Id = 2,
                CreateDate = new DateTime(2013, 1, 15, 21, 0, 0),
                VehicleId = taxi,
                City = gothenburg
            });

            _context.Tracings.Add(new Tracking
            {
                Id = 3,
                CreateDate = new DateTime(2013, 2, 7, 6, 23, 27),
                VehicleId = taxi,
                City = gothenburg
            });

            _context.Tracings.Add(new Tracking
            {
                Id = 4,
                CreateDate = new DateTime(2013, 2, 7, 15, 27, 0),
                VehicleId = taxi,
                City = gothenburg
            });

            _context.Tracings.Add(new Tracking
            {
                Id = 5,
                CreateDate = new DateTime(2013, 2, 8, 6, 27, 0),
                VehicleId = taxi,
                City = gothenburg
            });

            _context.Tracings.Add(new Tracking
            {
                Id = 6,
                CreateDate = new DateTime(2013, 2, 8, 6, 20, 27),
                VehicleId = taxi,
                City = gothenburg
            });

            _context.Tracings.Add(new Tracking
            {
                Id = 7,
                CreateDate = new DateTime(2013, 2, 8, 14, 35, 0),
                VehicleId = taxi,
                City = gothenburg
            });

            _context.Tracings.Add(new Tracking
            {
                Id = 8,
                CreateDate = new DateTime(2013, 2, 8, 15, 29, 0),
                VehicleId = taxi,
                City = gothenburg
            });

            _context.Tracings.Add(new Tracking
            {
                Id = 9,
                CreateDate = new DateTime(2013, 2, 8, 15, 47, 0),
                VehicleId = taxi,
                City = gothenburg
            });

            _context.Tracings.Add(new Tracking
            {
                Id = 10,
                CreateDate = new DateTime(2013, 2, 8, 16, 1, 0),
                VehicleId = taxi,
                City = gothenburg
            });

            _context.Tracings.Add(new Tracking
            {
                Id = 11,
                CreateDate = new DateTime(2013, 2, 8, 16, 48, 0),
                VehicleId = taxi,
                City = gothenburg
            });
            _context.Tracings.Add(new Tracking
            {
                Id = 12,
                CreateDate = new DateTime(2013, 2, 8, 17, 49, 0),
                VehicleId = taxi,
                City = gothenburg
            });
            _context.Tracings.Add(new Tracking
            {
                Id = 13,
                CreateDate = new DateTime(2013, 2, 8, 18, 29, 0),
                VehicleId = taxi,
                City = gothenburg
            });
            _context.Tracings.Add(new Tracking
            {
                Id = 14,
                CreateDate = new DateTime(2013, 2, 8, 18, 35, 0),
                VehicleId = taxi,
                City = gothenburg
            });
            _context.Tracings.Add(new Tracking
            {
                Id = 15,
                CreateDate = new DateTime(2013, 3, 26, 14, 25, 0),
                VehicleId = taxi,
                City = gothenburg
            });
            _context.Tracings.Add(new Tracking
            {
                Id = 16,
                CreateDate = new DateTime(2013, 3, 28, 14, 7, 27),
                VehicleId = taxi,
                City = gothenburg
            });
            #endregion

            #region Busses
            _context.Tracings.Add(new Tracking
            {
                Id = 17,
                CreateDate = new DateTime(2013, 4, 28, 14, 7, 27),
                VehicleId = busses,
                City = gothenburg
            });
            #endregion

            await _context.SaveChangesAsync();
        }
    }
}
