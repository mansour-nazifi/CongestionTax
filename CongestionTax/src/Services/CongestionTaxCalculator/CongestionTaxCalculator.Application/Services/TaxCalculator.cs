using CongestionTaxCalculator.Domain.DTO;
using CongestionTaxCalculator.Domain.Entities;
using CongestionTaxCalculator.Domain.Services;

namespace CongestionTaxCalculator.Application.Services
{
    public class TaxCalculator : ITaxCalculator
    {
        private const string Holidays_Country = "SE";
        private const int Categories_Less_Than_Minutes = 60;


        private readonly IHolidaysService holidaysService;

        public TaxCalculator(IHolidaysService holidaysService)
        {
            this.holidaysService = holidaysService;
        }

        public async Task<TaxCalculatorDTO> GetTax(List<Tracking> tracings, TaxRuleDTO[] taxRules, Vehicle vehicle)
        {
            var result = new TaxCalculatorDTO
            {
                Days = Grouping(tracings)
            };

            if (IsExemptVehicle(vehicle))
                return result;

            foreach (var day in result.Days)
            {
                if (await IsTaxFreeDate(day.Day))
                    continue;

                foreach (var subGroup in day.SubGroups)
                {
                    foreach (var item in subGroup.Tracings)
                    {
                        item.TaxRule = TaxForTracking(item.Tracking.CreateDate, taxRules);
                    }

                    CalculateLessThan60Minutes(subGroup);
                }

                CalculateDay(day);
            }

            CalculateTotalTax(result);

            return result;
        }

        private void CalculateLessThan60Minutes(SubGroupDTO subGroup)
        {
            var list = subGroup.Tracings.Where(x => x.TaxRule != null);
            if (list.Any())
                subGroup.Tax = list.Max(x => x.TaxRule.Amount);
        }
        private void CalculateDay(GroupsDTO group)
        {
            var sum = group.SubGroups.Sum(x => x.Tax);
            group.Tax = Math.Min(sum, 60);
        }
        private void CalculateTotalTax(TaxCalculatorDTO dailyTaxes)
        {
            if (dailyTaxes.Days.Any())
                dailyTaxes.Tax = dailyTaxes.Days.Sum(x => x.Tax);
        }

        private bool IsExemptVehicle(Vehicle vehicle) => vehicle.IsExempt;

        private TaxRuleDTO? TaxForTracking(DateTime date, TaxRuleDTO[] taxRules)
        {
            return taxRules
                .Where(x =>
                {
                    if (x.StartTime < x.EndTime)
                    {
                        return x.StartTime <= date.TimeOfDay && date.TimeOfDay <= x.EndTime;
                    }
                    else
                    {
                        return date.TimeOfDay >= x.StartTime || date.TimeOfDay <= x.EndTime;
                    }
                })
                .OrderByDescending(r => r.Amount)
                .FirstOrDefault();
        }

        private async Task<bool> IsTaxFreeDate(DateTime date)
        {
            if (date.Month == 7 || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return true;

            var holidays = await holidaysService.GetHolidays(date.Year, Holidays_Country);

            if (holidays.Contains(date.Date) || holidays.Any(x => x.Date.AddDays(-1) == date.Date))
                return true;

            return false;
        }

        /// <summary>
        /// Grouping by day and then items with a difference of less than 60 minutes
        /// </summary>       
        private List<GroupsDTO> Grouping(List<Tracking> tracings)
        {
            var result = new List<GroupsDTO>();

            if (tracings == null || tracings.Count == 0) return result;

            var dayGroup = tracings.GroupBy(d => d.CreateDate.Date).OrderBy(g => g.Key).ToList();

            foreach (var day in dayGroup)
            {
                var subGroups = new List<SubGroupDTO>();

                var currentSubGroup = new List<SubGroupItemDTO> { new SubGroupItemDTO { Tracking = day.First() } };

                foreach (var tracking in day.Skip(1))
                {
                    if ((tracking.CreateDate - currentSubGroup.First().Tracking.CreateDate).TotalMinutes <= Categories_Less_Than_Minutes)
                    {
                        currentSubGroup.Add(new SubGroupItemDTO { Tracking = tracking });
                    }
                    else
                    {
                        subGroups.Add(new SubGroupDTO { Tracings = currentSubGroup });
                        currentSubGroup = new List<SubGroupItemDTO> { new SubGroupItemDTO { Tracking = tracking } };
                    }
                }

                subGroups.Add(new SubGroupDTO { Tracings = currentSubGroup });

                result.Add(new GroupsDTO
                {
                    Day = day.Key,
                    SubGroups = subGroups
                });
            }

            return result;
        }
    }
}
