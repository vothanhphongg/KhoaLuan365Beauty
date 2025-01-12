using _365Beauty.Domain.Abstractions.Repositories;
using _365Beauty.Domain.Entities;

namespace _365Beauty.Query.Persistence.Repositories
{
    public class BeautySalonCatalogRepository(ApplicationDbContext context)
        : GenericRepository<BeautySalonCatalog, int>(context), IBeautySalonCatalogRepository
    {
    }
}