using _365Beauty.Command.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Command.Domain.Entities.Staffs;

namespace _365Beauty.Command.Persistence.Repositories.Staffs
{
    public class StaffCatalogRepository(ApplicationDbContext context) : GenericRepository<StaffCatalog, int>(context), IStaffCatalogRepository;
}
