using CongestionTaxCalculator.Domain.DTO;
using CongestionTaxCalculator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Services
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetVehicles();
        Task<Vehicle> GetVehicle(string name);
    }
}
