using CongestionTaxService.Application.TaxRules.Queries.GetTaxRules;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CongestionTaxService.Web.Controllers
{
    [Route("[controller]")]
    public class TaxRulesController : ControllerBase
    {
        private readonly ISender sender;

        public TaxRulesController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpGet]
        public async Task<IEnumerable<TaxRuleDto>> Get(GetTaxRulesQuery command)
        {
            if (command.City.IsNullOrEmpty())
                command.City = nameof(CongestionTaxCity.Cities.Gothenburg);

            return await sender.Send(command);
        }
    }
}
