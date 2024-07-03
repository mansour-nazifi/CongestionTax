using CongestionTaxCalculator.Domain.DTO;
using CongestionTaxCalculator.Domain.Entities;
using CongestionTaxCalculator.Domain.Services;
using FluentValidation;
using MediatR;

namespace CongestionTaxCalculator.Application.TaxCalculator.Queries.GetTax
{
    public record GetTaxQuery : IRequest<GetTaxDTO>
    {
        public string City { get; set; }
        public string Vehicle { get; set; }
    }

    public class GetTaxQueryValidator : AbstractValidator<GetTaxQuery>
    {
        public GetTaxQueryValidator()
        {
            RuleFor(v => v.Vehicle)
                .NotEmpty()
                .WithErrorCode("Vehicle is empty.");

            RuleFor(v => v.City)
                .NotEmpty()
                .WithErrorCode("City is empty.");
        }
    }

    public class GetTaxQueryHandler : IRequestHandler<GetTaxQuery, GetTaxDTO>
    {
        private readonly ITrackingService trackingService;
        private readonly ICongestionTaxService congestionTaxService;
        private readonly ITaxCalculator taxCalculator;
        private readonly IVehicleService vehicleService;

        public GetTaxQueryHandler(
            ITrackingService trackingService,
            ICongestionTaxService congestionTaxService,
            ITaxCalculator taxCalculator,
            IVehicleService vehicleService)
        {
            this.trackingService = trackingService;
            this.congestionTaxService = congestionTaxService;
            this.taxCalculator = taxCalculator;
            this.vehicleService = vehicleService;
        }

        public async Task<GetTaxDTO> Handle(GetTaxQuery request, CancellationToken cancellationToken)
        {
            var result = new GetTaxDTO
            {
                Vehicle = request.Vehicle,
                Vehicles = await vehicleService.GetVehicles(),

                City = request.City,
                Cities = Enum.GetNames(typeof(CongestionTaxCity.Cities)).Select(x => new CityDTO { Name = x })
            };

            var vehicle = await vehicleService.GetVehicle(request.Vehicle);

            if (vehicle == null)
                return result;

            var taxRules = await congestionTaxService.GetTaxRules(request.City);

            var tracings = await trackingService.GetTracings(vehicle, request.City);

            result.Tax = await taxCalculator.GetTax(tracings, taxRules, vehicle);

            return result;
        }
    }

    public class GetTaxDTO
    {
        public TaxCalculatorDTO Tax { get; set; }

        public string Vehicle { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public string City { get; set; }
        public IEnumerable<CityDTO> Cities { get; set; }
    }

    public class CityDTO
    {
        public string Name { get; set; }
    }
}

