using CleanArch.IntegrationTests.CrossCutting.Enum;

namespace CleanArch.IntegrationTests.Contracts.ViewModels
{
    public class CreateFinancialConfigurationViewModel
    {
        public decimal BaseSalary { get; set; }
        public ContractType ContractType { get; set; }
        public Guid UserId { get; set; }
        public int ConfigurationVersion { get; set; }
        public decimal? CustomHourlyRate { get; set; }
    }
}
