using CleanArch.IntegrationTests.CrossCutting.Common;
using CleanArch.IntegrationTests.CrossCutting.Enum;

namespace CleanArch.IntegrationTests.Domain.Entities
{
    public class FinancialConfiguration : BaseEntity
    {
        public decimal BaseSalary { get; private set; }
        public ContractType ContractType { get; private set; }
        public DateTime RegisteredAt { get; private set; }
        public Guid UserId { get; private set; }
        public int ConfigurationVersion { get; private set; }
        public decimal HourlyRate { get; private set; }
        public DateTime RegistrationDate { get; set; }

        protected FinancialConfiguration() { }

        public FinancialConfiguration(decimal baseSalary, ContractType contractType, Guid userId, int configurationVersion, decimal? customHourlyRate = null)
        {
            Id = Guid.NewGuid();
            BaseSalary = baseSalary;
            ContractType = contractType;
            UserId = userId;
            ConfigurationVersion = configurationVersion;
            RegisteredAt = DateTime.UtcNow;
            RegistrationDate = DateTime.UtcNow;

            Validate();
            HourlyRate = customHourlyRate ?? CalculateHourlyRate();
        }

        private decimal CalculateHourlyRate()
        {
            const int monthlyHours = 220;
            return Math.Round(BaseSalary / monthlyHours, 2);
        }

        private void Validate()
        {
            if (BaseSalary <= 0)
                throw new Exception("Base salary must be greater than zero.");

            if (!Enum.IsDefined(typeof(ContractType), ContractType))
                throw new Exception("Invalid contract type.");
        }
    }
}
