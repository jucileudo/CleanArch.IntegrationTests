using AutoMapper;
using CleanArch.IntegrationTests.CrossCutting.Common;
using CleanArch.IntegrationTests.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace CleanArch.IntegrationTests.Application.Commons
{
    public abstract class ServiceBase<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly IMapper Mapper;
        protected readonly ILogger Logger;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IRepository<TEntity> Repository;
        protected readonly Guid AuthenticatedUserId;

        protected ServiceBase(
            IMapper mapper,
            ILogger logger,
            IUnitOfWork unitOfWork,
            IRepository<TEntity> repository,
            Guid authenticatedUserId)
        {
            Mapper = mapper;
            Logger = logger;
            UnitOfWork = unitOfWork;
            Repository = repository;
            AuthenticatedUserId = authenticatedUserId;
        }

        // Optional helper - extend if needed
        protected OperationMessageBuilder MessageBuilder()
        {
            return new OperationMessageBuilder(this);
        }
    }
}
