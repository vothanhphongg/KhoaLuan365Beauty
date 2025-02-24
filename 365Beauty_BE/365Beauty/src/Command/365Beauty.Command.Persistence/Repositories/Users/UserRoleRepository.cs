using _365Beauty.Command.Domain.Abstractions.Repositories.Users;
using _365Beauty.Command.Domain.Entities.Users;

namespace _365Beauty.Command.Persistence.Repositories.Users
{
    public class UserRoleRepository(ApplicationDbContext context) : GenericRepository<UserRole, int>(context), IUserRoleRepository;
}