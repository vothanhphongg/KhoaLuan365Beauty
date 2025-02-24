using _365Beauty.Command.Domain.Abstractions.Repositories.Services;
using _365Beauty.Command.Domain.Entities.Services;

namespace _365Beauty.Command.Persistence.Repositories.Services
{
    public class ServiceCatalogRepository(ApplicationDbContext context) : GenericRepository<ServiceCatalog, int>(context), IServiceCatalogRepository;
}