using Ardalis.GuardClauses;
using CongestionTaxCalculator.Application.Common.Interfaces;
using CongestionTaxCalculator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);

        return services;
    }

    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
        {
            options.UseInMemoryDatabase("CongestionTaxCalculator");
        });

        services.AddScoped<ApplicationDbContextInitialiser>();

        return services;
    }
}