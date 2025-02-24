using _365Beauty.Query.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Query.Domain.Entities.BeautySalons;

namespace _365Beauty.Query.Persistence.Repositories.BeautySalons
{
    public class BeautySalonServiceRepository(ApplicationDbContext context)
        : GenericRepository<BeautySalonService, int>(context), IBeautySalonServiceRepository;
}