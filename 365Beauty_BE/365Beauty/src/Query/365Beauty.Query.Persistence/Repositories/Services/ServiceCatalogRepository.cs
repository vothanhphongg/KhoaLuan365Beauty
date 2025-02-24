using _365Beauty.Query.Domain.Abstractions.Repositories.Services;
using _365Beauty.Query.Domain.Entities.Services;

namespace _365Beauty.Query.Persistence.Repositories.Services
{
    public class ServiceCatalogRepository(ApplicationDbContext context) : GenericRepository<ServiceCatalog, int>(context), IServiceCatalogRepository;
}