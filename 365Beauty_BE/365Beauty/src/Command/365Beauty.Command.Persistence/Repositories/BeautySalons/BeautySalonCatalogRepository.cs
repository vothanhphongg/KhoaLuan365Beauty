using _365Beauty.Command.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Command.Domain.Entities.BeautySalons;

namespace _365Beauty.Command.Persistence.Repositories.BeautySalons
{
    public class BeautySalonCatalogRepository(ApplicationDbContext context) : GenericRepository<BeautySalonCatalog, int>(context), IBeautySalonCatalogRepository;
}