

using CleanArch.IntegrationTests.CrossCutting.Enum;

namespace CleanArch.IntegrationTests.Contracts.ViewModels
{
    public class CreateTaxParameterViewModel
    {
        public TaxType TaxType { get; set; }
        public int EffectiveYear { get; set; }
        public decimal MinimumBase { get; set; }
        public decimal? MaximumBase { get; set; }
        public decimal Rate { get; set; }
        public decimal Deduction { get; set; }
    }
}
