using CongestionTaxCalculator.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Services
{
    public interface ICongestionTaxService
    {
        Task<TaxRuleDTO[]> GetTaxRules(string city);
    }
}
