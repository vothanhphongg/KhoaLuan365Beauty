using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application_Queries.Users.UserBookings;
using _365Beauty.Query.Domain.Abstractions.Repositories.Users;
using _365Beauty.Query.Domain.Entities.Users;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Users.UserBookings
{
    public class GetDetailUserBookingHandler : IRequestHandler<GetDetailUserBookingQuery, Result<UserBooking>>
    {
        private readonly IUserBookingRepository userBookingRepository;
        private readonly IMediator mediator;

        public GetDetailUserBookingHandler(IUserBookingRepository userBookingRepository)
        {
            this.userBookingRepository = userBookingRepository;
            this.mediator = mediator;
        }
        public async Task<Result<UserBooking>> Handle(GetDetailUserBookingQuery request, CancellationToken cancellationToken)
        {
            var entity = await userBookingRepository.FindByIdAsync(request.Id, false, true, cancellationToken, x => x.Time, x => x.BookingType);
            
            return Result.Ok(entity);
        }
    }
}