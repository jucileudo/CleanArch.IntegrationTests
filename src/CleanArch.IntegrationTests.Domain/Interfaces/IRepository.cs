using CleanArch.IntegrationTests.CrossCutting.Common;

namespace CleanArch.IntegrationTests.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<bool> AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        Task<bool> ExistsAsync(Guid id);
        Task SaveChangesAsync();
        Task<TResult?> QueryAsync<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> query);
        Task<List<TResult>> QueryListAsync<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> query);
    }
}
