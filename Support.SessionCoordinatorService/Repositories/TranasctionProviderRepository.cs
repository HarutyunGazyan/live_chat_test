using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Shared.Library.Entities;
using SessionCoordinatorService.Services;

namespace SessionCoordinatorService.Repositories
{
    public class TranasctionProviderRepository : ITranasctionProviderRepository
    {
        private readonly SupportDbContext _dbContext;

        public TranasctionProviderRepository(SupportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return  await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction(IDbContextTransaction transaction)
        {
            await transaction.CommitAsync();
        }

        public async Task RollbackTransaction(IDbContextTransaction transaction)
        {
            await transaction.RollbackAsync();
        }

        public async Task DisposeTransaction(IDbContextTransaction transaction)
        {
            await transaction.DisposeAsync();
        }
    }
}
