using CongestionTaxCalculator.Application.Common.Behaviours;
using CongestionTaxCalculator.Application.Services;
using CongestionTaxCalculator.Application.TaxCalculator.Queries.GetTax;
using CongestionTaxCalculator.Domain.Services;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        });

        services.AddSingleton<HttpClient>()
                .AddTransient<IHolidaysService, HolidayService>()
                .AddTransient<ICongestionTaxService, CongestionTaxService>()
                .AddTransient<ITaxCalculator, TaxCalculator>()
                .AddTransient<IVehicleService, VehicleService>()
                .AddTransient<ITrackingService, TrackingService>();

        return services;
    }
}
