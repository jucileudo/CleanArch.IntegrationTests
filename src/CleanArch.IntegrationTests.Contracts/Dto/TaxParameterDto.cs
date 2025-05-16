using CleanArch.IntegrationTests.CrossCutting.Enum;

namespace CleanArch.IntegrationTests.Contracts.Dto
{
    public class TaxParameterDto
    {
        public Guid Id { get; set; }
        public TaxType TaxType { get; set; }
        public int EffectiveYear { get; set; }
        public decimal MinimumBase { get; set; }
        public decimal? MaximumBase { get; set; }
        public decimal Rate { get; set; }
        public decimal Deduction { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
