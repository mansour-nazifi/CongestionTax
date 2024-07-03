using CongestionTaxCalculator.Domain.DTO;
using CongestionTaxCalculator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Services
{
    public interface ITrackingService
    {
        Task<List<Tracking>> GetTracings(Vehicle vehicle, string city);
    }
}
