using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.Queries.Bookings.BookingTypes;
using _365Beauty.Query.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Query.Domain.Entities.Bookings;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Bookings.BookingTypes
{
    public class GetAllBookingTypeHandler : IRequestHandler<GetAllBookingTypeQuery, Result<List<BookingType>>>
    {
        private readonly IBookingTypeRepository bookingTypeRepository;

        public GetAllBookingTypeHandler(IBookingTypeRepository bookingTypeRepository)
        {
            this.bookingTypeRepository = bookingTypeRepository;
        }

        public async Task<Result<List<BookingType>>> Handle(GetAllBookingTypeQuery request, CancellationToken cancellationToken)
        {
            var entity = bookingTypeRepository.FindAll().ToList();
            return await Task.FromResult(Result.Ok(entity));
        }
    }
}