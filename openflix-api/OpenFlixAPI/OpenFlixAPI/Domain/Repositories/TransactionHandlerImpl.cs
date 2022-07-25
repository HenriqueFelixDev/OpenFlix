using Microsoft.EntityFrameworkCore.Storage;

namespace OpenFlixAPI.Domain.Repositories
{
    public class TransactionHandlerImpl : ITransactionHandler
    {
        private readonly Context _context;
        public TransactionHandlerImpl(Context context)
        {
            _context = context;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
