using _365Beauty.Query.Domain.Abstractions.Repositories.Localizations;
using _365Beauty.Query.Domain.Entities.Localizations;

namespace _365Beauty.Query.Persistence.Repositories.Localizations
{
    public class WardRepository(ApplicationDbContext context) : GenericRepository<Ward, string>(context), IWardRepository;
}