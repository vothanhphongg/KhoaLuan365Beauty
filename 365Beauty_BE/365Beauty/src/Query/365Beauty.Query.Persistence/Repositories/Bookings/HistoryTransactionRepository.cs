using _365Beauty.Query.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Query.Domain.Entities.Bookings;

namespace _365Beauty.Query.Persistence.Repositories.Bookings
{
    public class HistoryTransactionRepository(ApplicationDbContext context) : GenericRepository<HistoryTransaction, int>(context), IHistoryTransactionRepository;
}