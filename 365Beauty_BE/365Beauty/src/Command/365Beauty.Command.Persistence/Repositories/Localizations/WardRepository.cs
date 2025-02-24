using _365Beauty.Command.Domain.Abstractions.Repositories.Localizations;
using _365Beauty.Command.Domain.Entities.Localizations;

namespace _365Beauty.Command.Persistence.Repositories.Localizations
{
    public class WardRepository(ApplicationDbContext context) : GenericRepository<Ward, string>(context), IWardRepository;
}