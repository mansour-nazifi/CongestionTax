using CongestionTaxCalculator.Domain.Entities;

namespace CongestionTaxCalculator.Domain.DTO
{
    public class TaxCalculatorDTO
    {
        public int Tax { get; set; } = 0;
        public List<GroupsDTO> Days { get; set; }
    }
    public class GroupsDTO
    {
        public DateTime Day { get; set; }
        public List<SubGroupDTO> SubGroups { get; set; }
        public int Tax { get; set; } = 0;
    }
    public class SubGroupDTO
    {
        public List<SubGroupItemDTO> Tracings { get; set; }
        public int Tax { get; set; } = 0;
    }
    public class SubGroupItemDTO
    {
        public Tracking Tracking { get; set; }
        public TaxRuleDTO TaxRule { get; set; }
    }
}
