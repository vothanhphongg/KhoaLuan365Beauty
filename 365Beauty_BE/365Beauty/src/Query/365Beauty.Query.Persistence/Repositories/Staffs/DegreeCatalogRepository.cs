using _365Beauty.Query.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Query.Domain.Entities.Staffs;

namespace _365Beauty.Query.Persistence.Repositories.Staffs
{
    public class DegreeCatalogRepository(ApplicationDbContext context) : GenericRepository<DegreeCatalog, int>(context), IDegreeCatalogRepository;
}