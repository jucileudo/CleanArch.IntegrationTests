using CleanArch.IntegrationTests.Contracts.Dto;
using CleanArch.IntegrationTests.Contracts.ViewModels;
using CleanArch.IntegrationTests.CrossCutting.Common;

namespace CleanArch.IntegrationTests.Contracts.Services
{
    public interface ITaxParameterService
    {
        Task<OperationResult<TaxParameterDto>> CreateAsync(CreateTaxParameterViewModel viewModel);
        Task<OperationResult<List<TaxParameterDto>>> GetAllAsync();
        Task<OperationResult<TaxParameterDto>> GetByIdAsync(Guid id);
        Task<OperationResult<bool>> DeactivateAsync(Guid id);
    }
}
