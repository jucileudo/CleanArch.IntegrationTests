namespace CleanArch.IntegrationTests.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
