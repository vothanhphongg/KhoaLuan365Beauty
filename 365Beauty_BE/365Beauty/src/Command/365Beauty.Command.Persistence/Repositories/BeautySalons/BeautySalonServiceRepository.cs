using _365Beauty.Command.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Command.Domain.Entities.BeautySalons;

namespace _365Beauty.Command.Persistence.Repositories.BeautySalons
{
    public class BeautySalonServiceRepository(ApplicationDbContext context) : GenericRepository<BeautySalonService, int>(context), IBeautySalonServiceRepository;
}