using CleanArch.IntegrationTests.Domain.Interfaces;
using CleanArch.IntegrationTests.Infra.Data.Context;

namespace CleanArch.IntegrationTests.Infra.Data.UoW
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;


        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
