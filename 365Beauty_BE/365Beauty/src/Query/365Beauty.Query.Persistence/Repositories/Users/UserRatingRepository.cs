using _365Beauty.Query.Domain.Abstractions.Repositories.Users;
using _365Beauty.Query.Domain.Entities.Users;

namespace _365Beauty.Query.Persistence.Repositories.Users
{
    public class UserRatingRepository(ApplicationDbContext context) : GenericRepository<UserRating, int>(context), IUserRatingRepository;
}