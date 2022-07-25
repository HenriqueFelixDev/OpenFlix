using Microsoft.EntityFrameworkCore.Storage;

namespace OpenFlixAPI.Domain.Repositories
{
    public interface ITransactionHandler
    {
        public IDbContextTransaction BeginTransaction();
    }
}
