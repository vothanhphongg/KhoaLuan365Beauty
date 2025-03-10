using _365Beauty.Query.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Query.Domain.Entities.BeautySalons;

namespace _365Beauty.Query.Persistence.Repositories.BeautySalons
{
    public class BeautySalonCatalogRepository(ApplicationDbContext context) : GenericRepository<BeautySalonCatalog, int>(context), IBeautySalonCatalogRepository;
}