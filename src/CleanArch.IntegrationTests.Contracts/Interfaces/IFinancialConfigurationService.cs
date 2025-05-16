using CleanArch.IntegrationTests.Contracts.Dto;
using CleanArch.IntegrationTests.Contracts.ViewModels;
using CleanArch.IntegrationTests.CrossCutting.Common;

namespace CleanArch.IntegrationTests.Contracts.Services
{
    public interface IFinancialConfigurationService
    {
        Task<OperationResult<FinancialConfigurationDto>> CreateAsync(CreateFinancialConfigurationViewModel viewModel);
        Task<OperationResult<List<FinancialConfigurationDto>>> GetAllAsync();
        Task<OperationResult<FinancialConfigurationDto>> GetByIdAsync(Guid id);
        Task<OperationResult<bool>> DeactivateAsync(Guid id);
    }
}
