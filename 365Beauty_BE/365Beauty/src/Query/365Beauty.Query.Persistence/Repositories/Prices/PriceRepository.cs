using _365Beauty.Query.Domain.Abstractions.Repositories.Prices;
using _365Beauty.Query.Domain.Entities.Prices;

namespace _365Beauty.Query.Persistence.Repositories.Prices
{
    public class PriceRepository(ApplicationDbContext context) : GenericRepository<Price, int>(context), IPriceRepository;
}