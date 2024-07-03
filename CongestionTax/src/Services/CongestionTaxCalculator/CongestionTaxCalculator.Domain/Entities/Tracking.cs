using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Entities
{
    public class Tracking
    {
        public int Id { get; set; }
        public string City { get; set; }
        public DateTime CreateDate { get; set; }

        public string VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
