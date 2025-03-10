using _365Beauty.Query.Domain.Abstractions.Repositories.Users;
using _365Beauty.Query.Domain.Entities.Users;
using _365Beauty.Query.Persistence;
using _365Beauty.Query.Persistence.Repositories;

namespace Repositories.Users
{
    public class UserBookingRepository(ApplicationDbContext context) : GenericRepository<UserBooking, int>(context), IUserBookingRepository;
}