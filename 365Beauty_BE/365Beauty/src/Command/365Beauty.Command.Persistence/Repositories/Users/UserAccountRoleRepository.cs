using _365Beauty.Command.Domain.Abstractions.Repositories.Users;
using _365Beauty.Command.Domain.Entities.Users;

namespace _365Beauty.Command.Persistence.Repositories.Users
{
    internal class UserAccountRoleRepository(ApplicationDbContext context) : GenericRepository<UserAccountRole, int>(context), IUserAccountRoleRepository;
}