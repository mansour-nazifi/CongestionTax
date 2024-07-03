using CongestionTaxCalculator.Domain.DTO;
using CongestionTaxCalculator.Domain.Services;
using Newtonsoft.Json;

namespace CongestionTaxCalculator.Application.Services
{
    public class CongestionTaxService : ICongestionTaxService
    {
        private const string ApiUrl = "http://localhost:5256";

        private readonly HttpClient httpClient;        

        public CongestionTaxService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<TaxRuleDTO[]> GetTaxRules(string city)
        {
            var url = $"{ApiUrl}/TaxRules?city={city}";

            var response = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<TaxRuleDTO[]>(response);
        }
    }
}
