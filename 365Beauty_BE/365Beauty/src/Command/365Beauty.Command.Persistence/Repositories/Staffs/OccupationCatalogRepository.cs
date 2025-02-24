using _365Beauty.Command.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Command.Domain.Entities.Staffs;

namespace _365Beauty.Command.Persistence.Repositories.Staffs
{
    public class OccupationCatalogRepository(ApplicationDbContext context) : GenericRepository<OccupationCatalog, int>(context), IOccupationCatalogRepository;
}