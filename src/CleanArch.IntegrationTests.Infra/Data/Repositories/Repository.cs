using CleanArch.IntegrationTests.CrossCutting.Common;
using CleanArch.IntegrationTests.Domain.Interfaces;
using CleanArch.IntegrationTests.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.IntegrationTests.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return IsEntityBeingTrackedAsAdded(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dbSet.AnyAsync(e => e.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TResult> QueryAsync<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> query)
        {
            return await query(_dbSet.AsQueryable()).FirstOrDefaultAsync();
        }

        public async Task<List<TResult>> QueryListAsync<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> query)
        {
            return await query(_dbSet.AsQueryable()).ToListAsync();
        }

        private bool IsEntityBeingTrackedAsAdded(TEntity entity)
        {
            var entry = _context.Entry(entity);
            return entry.State == EntityState.Added;
        }
    }
}
