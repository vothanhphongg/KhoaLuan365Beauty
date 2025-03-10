using _365Beauty.Command.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Command.Domain.Entities.Bookings;

namespace _365Beauty.Command.Persistence.Repositories.Bookings
{
    public class HistoryTransactionRepository(ApplicationDbContext context) : GenericRepository<HistoryTransaction, int>(context), IHistoryTransactionRepository;
}