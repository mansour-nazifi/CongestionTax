using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Services
{
    public interface IHolidaysService
    {
        Task<List<DateTime>> GetHolidays(int year, string countryCode);
    }
}
