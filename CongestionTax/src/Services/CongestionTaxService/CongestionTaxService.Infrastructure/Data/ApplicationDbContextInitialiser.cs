using CongestionTaxService.Application.Common.Interfaces;
using CongestionTaxService.Domain.Entities;

namespace CongestionTaxService.Infrastructure.Data;
public class ApplicationDbContextInitialiser
{
    private readonly IApplicationDbContext _context;

    public ApplicationDbContextInitialiser(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        if (!_context.TaxRules.Any())
        {
            var gothenburg = nameof(CongestionTaxCity.Cities.Gothenburg);

            _context.TaxRules.Add(new TaxRule
            {
                City = gothenburg,
                StartTime = new TimeSpan(6, 0, 0),
                EndTime = new TimeSpan(6, 29, 0),
                Amount = 8
            });
            _context.TaxRules.Add(new TaxRule
            {
                City = gothenburg,
                StartTime = new TimeSpan(6, 30, 0),
                EndTime = new TimeSpan(6, 59, 0),
                Amount = 13
            });
            _context.TaxRules.Add(new TaxRule
            {
                City = gothenburg,
                StartTime = new TimeSpan(7, 0, 0),
                EndTime = new TimeSpan(7, 59, 0),
                Amount = 18
            });
            _context.TaxRules.Add(new TaxRule
            {
                City = gothenburg,
                StartTime = new TimeSpan(8, 0, 0),
                EndTime = new TimeSpan(8, 29, 0),
                Amount = 8
            });
            _context.TaxRules.Add(new TaxRule
            {
                City = gothenburg,
                StartTime = new TimeSpan(8, 30, 0),
                EndTime = new TimeSpan(14, 59, 0),
                Amount = 8
            });

            _context.TaxRules.Add(new TaxRule
            {
                City = gothenburg,
                StartTime = new TimeSpan(15, 0, 0),
                EndTime = new TimeSpan(15, 29, 0),
                Amount = 13
            });
            _context.TaxRules.Add(new TaxRule
            {
                City = gothenburg,
                StartTime = new TimeSpan(15, 30, 0),
                EndTime = new TimeSpan(16, 59, 0),
                Amount = 18
            });
            _context.TaxRules.Add(new TaxRule
            {
                City = gothenburg,
                StartTime = new TimeSpan(17, 0, 0),
                EndTime = new TimeSpan(17, 59, 0),
                Amount = 13
            });
            _context.TaxRules.Add(new TaxRule
            {
                City = gothenburg,
                StartTime = new TimeSpan(18, 00, 0),
                EndTime = new TimeSpan(18, 29, 0),
                Amount = 8
            });
            //The best thing was to separate this rule into two records.
            _context.TaxRules.Add(new TaxRule
            {
                City = gothenburg,
                StartTime = new TimeSpan(18, 30, 0),
                EndTime = new TimeSpan(5, 59, 0),
                Amount = 0
            });

            await _context.SaveChangesAsync();
        }
    }
}
