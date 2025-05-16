using CleanArch.IntegrationTests.CrossCutting.Enum;

namespace CleanArch.IntegrationTests.Contracts.Dto
{
    public class FinancialConfigurationDto
    {
        public Guid Id { get; set; }
        public decimal BaseSalary { get; set; }
        public ContractType ContractType { get; set; }
        public DateTime RegisteredAt { get; set; }
        public Guid UserId { get; set; }
        public int ConfigurationVersion { get; set; }
        public decimal HourlyRate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}
