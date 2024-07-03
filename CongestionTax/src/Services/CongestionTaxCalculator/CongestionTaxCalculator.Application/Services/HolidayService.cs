using CongestionTaxCalculator.Domain.Services;
using Newtonsoft.Json;

namespace CongestionTaxCalculator.Application.Services
{
    public class HolidayService : IHolidaysService
    {
        private const string Api_Url = "https://calendarific.com/api/v2/holidays";
        private const string Api_Key = "9RuwBik4CN19Cvo2ENBUeGKpl5hwTNYL";
        private const int Default_Year = 2013;

        private readonly HttpClient httpClient;

        private static Dictionary<string, List<DateTime>> _instance = new Dictionary<string, List<DateTime>>();

        public HolidayService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<DateTime>> GetHolidays(int year, string countryCode)
        {
            try
            {
                var key = $"{year}_{countryCode}";

                if (_instance.ContainsKey(key))
                    return _instance[key];

                var url = $"{Api_Url}?api_key={Api_Key}&country={countryCode}&year={year}";
                var response = await httpClient.GetStringAsync(url);
                var apiResponse = JsonConvert.DeserializeObject<HolidayServiceDTO>(response);

                var items = apiResponse.Response.Holidays
                    .Select(h => DateTime.Parse(h.Date.Iso))
                    .ToList();

                _instance.Add(key, items);

                return items;
            }
            catch
            {
                //If the service does not work 
                return [
                    new DateTime(Default_Year, 1, 1),    // New Year's Day
                    new DateTime(Default_Year, 1, 6),    // Epiphany
                    new DateTime(Default_Year, 3, 29),   // Good Friday
                    new DateTime(Default_Year, 3, 31),   // Easter Sunday
                    new DateTime(Default_Year, 4, 1),    // Easter Monday
                    new DateTime(Default_Year, 5, 1),    // May Day
                    new DateTime(Default_Year, 5, 9),    // Ascension Day
                    new DateTime(Default_Year, 6, 6),    // National Day of Sweden
                    new DateTime(Default_Year, 6, 22),   // Midsummer Day
                    new DateTime(Default_Year, 11, 2),   // All Saints' Day
                    new DateTime(Default_Year, 12, 25),  // Christmas Day
                    new DateTime(Default_Year, 12, 26)   // Boxing Day
                ];
            }
        }

        private class HolidayServiceDTO
        {
            public HolidayResponse Response { get; set; }
        }
        private class HolidayResponse
        {
            public List<Holiday> Holidays { get; set; }
        }
        private class Holiday
        {
            public Date Date { get; set; }
            public string Name { get; set; }
        }

        private class Date
        {
            public string Iso { get; set; }
        }
    }
}
