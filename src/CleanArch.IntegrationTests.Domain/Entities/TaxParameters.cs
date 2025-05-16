using CleanArch.IntegrationTests.CrossCutting.Common;
using CleanArch.IntegrationTests.CrossCutting.Enum;

namespace CearaCode.Protasker.Domain.Entities.FinancialSettings
{
    public class TaxParameters : BaseEntity
    {
        public TaxType TaxType { get; private set; }
        public int EffectiveYear { get; private set; }
        public decimal MinimumBase { get; private set; }
        public decimal? MaximumBase { get; private set; }
        public decimal Rate { get; private set; }
        public decimal Deduction { get; private set; }

        protected TaxParameters() { }

        public TaxParameters(
            TaxType taxType,
            int effectiveYear,
            decimal minimumBase,
            decimal? maximumBase,
            decimal rate,
            bool active,
            decimal deduction)
        {
            Id = Guid.NewGuid();
            TaxType = taxType;
            EffectiveYear = effectiveYear;
            MinimumBase = minimumBase;
            MaximumBase = maximumBase;
            Rate = rate;
            Deduction = deduction;
            active = active;

            Validate();
        }

        public void Deactivate()
        {
            Active = false;
        }

        private void Validate()
        {
            if (EffectiveYear < 2000)
                throw new Exception("Effective year must be 2000 or later.");
            if (MinimumBase < 0)
                throw new Exception("Minimum base must be greater than or equal to 0.");
            if (MaximumBase.HasValue && MaximumBase <= MinimumBase)
                throw new Exception("Maximum base must be greater than the minimum base.");
            if (Rate < 0 || Rate > 100)
                throw new Exception("Rate must be between 0 and 100.");
            if (Deduction < 0)
                throw new Exception("Deduction cannot be negative.");
        }
    }
}
