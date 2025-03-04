using _365Beauty.Query.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Query.Domain.Entities.Users;

namespace _365Beauty.Query.Persistence.Repositories.Bookings
{
    public class UserBookingRepository(ApplicationDbContext context)
        : GenericRepository<UserBooking, int>(context), IUserBookingRepository;
}