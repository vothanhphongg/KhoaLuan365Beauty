using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.Queries.Bookings.BookingTypes;
using _365Beauty.Query.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Query.Domain.Entities.Bookings;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Bookings.BookingTypes
{
    public class GetDetailBookingTypeHandler : IRequestHandler<GetDetailBookingTypeQuery, Result<BookingType>>
    {
        private readonly IBookingTypeRepository bookingTypeRepository;

        public GetDetailBookingTypeHandler(IBookingTypeRepository bookingTypeRepository)
        {
            this.bookingTypeRepository = bookingTypeRepository;
        }

        public async Task<Result<BookingType>> Handle(GetDetailBookingTypeQuery request, CancellationToken cancellationToken)
        {
            var entity = await bookingTypeRepository.FindByIdAsync(request.Id, false, true, cancellationToken);
            return Result.Ok(entity);
        }
    }
}