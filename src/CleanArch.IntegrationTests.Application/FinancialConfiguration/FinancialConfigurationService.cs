using AutoMapper;
using CleanArch.IntegrationTests.Application.Commons;
using CleanArch.IntegrationTests.Contracts.Dto;
using CleanArch.IntegrationTests.Contracts.Services;
using CleanArch.IntegrationTests.Contracts.ViewModels;
using CleanArch.IntegrationTests.CrossCutting.Common;
using CleanArch.IntegrationTests.Domain.Entities;
using CleanArch.IntegrationTests.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace CleanArch.IntegrationTests.Application.Services
{
    public class FinancialConfigurationService(
        IMapper mapper,
        ILogger<FinancialConfigurationService> logger,
        IUnitOfWork unitOfWork,
        IRepository<FinancialConfiguration> repository,
        Guid authenticatedUserId) : ServiceBase<FinancialConfiguration>(mapper, logger, unitOfWork, repository, authenticatedUserId), IFinancialConfigurationService
    {
        public async Task<OperationResult<FinancialConfigurationDto>> CreateAsync(CreateFinancialConfigurationViewModel viewModel)
        {
            try
            {
                var entity = new FinancialConfiguration(
                    viewModel.BaseSalary,
                    viewModel.ContractType,
                    viewModel.UserId,
                    viewModel.ConfigurationVersion,
                    viewModel.CustomHourlyRate
                );

                await Repository.AddAsync(entity);
                await UnitOfWork.CommitAsync();

                var dto = Mapper.Map<FinancialConfigurationDto>(entity);
                return new OperationResult<FinancialConfigurationDto>(true, dto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error while creating financial configuration");
                return new OperationResult<FinancialConfigurationDto>(false, default, new[]
                {
                    new OperationMessage("ERR-CFG-CRT", "An unexpected error occurred while creating the configuration.")
                });

            }
        }

        public async Task<OperationResult<List<FinancialConfigurationDto>>> GetAllAsync()
        {
            try
            {
                var entities = await Repository.GetAllAsync();
                var activeEntities = entities.Where(e => (e.Active ?? false)).ToList();
                var dtos = Mapper.Map<List<FinancialConfigurationDto>>(activeEntities);

                return new OperationResult<List<FinancialConfigurationDto>>(true, dtos);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error while retrieving financial configurations");
                return new OperationResult<List<FinancialConfigurationDto>>(false, default,
                [
                    new OperationMessage("ERR-CFG-ALL", "Failed to retrieve the configurations.")
                ]);
            }
        }

        public async Task<OperationResult<FinancialConfigurationDto>> GetByIdAsync(Guid id)
        {
            try
            {
                var entity = await Repository.GetByIdAsync(id);

                if (entity == null || !(entity.Active ?? false))
                    return new OperationResult<FinancialConfigurationDto>(false, default,
                    [
                        new OperationMessage("ERR-CFG-NOTFOUND", "Configuration not found.")
                    ]);

                var dto = Mapper.Map<FinancialConfigurationDto>(entity);
                return new OperationResult<FinancialConfigurationDto>(true, dto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error while retrieving configuration by ID");
                return new OperationResult<FinancialConfigurationDto>(false, default,
                [
                    new OperationMessage("ERR-CFG-ID", "Failed to retrieve the configuration.")
                ]);
            }
        }

        public async Task<OperationResult<bool>> DeactivateAsync(Guid id)
        {
            try
            {
                var entity = await Repository.GetByIdAsync(id);

                if (entity == null || !(entity.Active ?? false))
                    return new OperationResult<bool>(false, false, new[]
                    {
                        new OperationMessage("ERR-CFG-NOTFOUND", "Configuration not found.")
                    });

                entity.Deactivate();
                Repository.Update(entity);
                await UnitOfWork.CommitAsync();

                return new OperationResult<bool>(true, true);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error while deactivating configuration");
                return new OperationResult<bool>(false, false, new[]
                {
                    new OperationMessage("ERR-CFG-DEACT", "Failed to deactivate the configuration.")
                });
            }
        }
    }
}
