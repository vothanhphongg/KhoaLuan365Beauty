using _365Beauty.Command.Domain.Abstractions.Repositories.Prices;
using _365Beauty.Command.Domain.Entities.Prices;

namespace _365Beauty.Command.Persistence.Repositories.Prices
{
    public class PriceRepository(ApplicationDbContext context) : GenericRepository<Price, int>(context), IPriceRepository;
}