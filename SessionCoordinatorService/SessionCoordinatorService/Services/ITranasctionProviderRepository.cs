using Microsoft.EntityFrameworkCore.Storage;

namespace SessionCoordinatorService.Services
{
    public interface ITranasctionProviderRepository
    {
        Task<IDbContextTransaction> BeginTransaction();

        Task CommitTransaction(IDbContextTransaction transaction);

        Task RollbackTransaction(IDbContextTransaction transaction);

        Task DisposeTransaction(IDbContextTransaction transaction);
    }
}