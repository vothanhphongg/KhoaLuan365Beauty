using _365Beauty.Command.Domain.Abstractions.Repositories.Prices;
using _365Beauty.Command.Domain.Entities.Prices;

namespace _365Beauty.Command.Persistence.Repositories.Prices
{
    public class PriceHistoryRepository(ApplicationDbContext context) : GenericRepository<PriceHistory, int>(context), IPriceHistoryRepository;
}