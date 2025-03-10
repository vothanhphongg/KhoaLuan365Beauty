using _365Beauty.Command.Domain.Entities.Bookings;

namespace _365Beauty.Command.Domain.Abstractions.Repositories.Bookings
{
    public interface IHistoryTransactionRepository : IGenericRepository<HistoryTransaction, int>;
}