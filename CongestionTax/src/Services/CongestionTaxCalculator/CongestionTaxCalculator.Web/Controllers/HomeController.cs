using CongestionTaxCalculator.Application.TaxCalculator.Queries.GetTax;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CongestionTaxCalculator.Web.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ISender sender;

        public HomeController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpGet("/")]
        public async Task<IActionResult> Index(GetTaxQuery command)
        {
            if (command.City.IsNullOrEmpty())
                command.City = nameof(CongestionTaxCity.Cities.Gothenburg);

            if (command.Vehicle.IsNullOrEmpty())
                command.Vehicle = "Taxi";

            return View(await sender.Send(command));
        }
    }
}
