using _365Beauty.Domain.Abstractions.Repositories;
using _365Beauty.Domain.Entities;

namespace _365Beauty.Command.Persistence.Repositories
{
    public class UserAccoutRepository(ApplicationDbContext context) : GenericRepository<UserAccount, int>(context), IUserAccountRepository;
}