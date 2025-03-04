using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.Queries.Bookings.Times;
using _365Beauty.Query.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Query.Domain.Entities.Bookings;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Bookings.Times
{
    public class GetDetailTimeHandler : IRequestHandler<GetDetailTimeQuery, Result<Time>>
    {
        private readonly ITimeRepository bookingTypeRepository;

        public GetDetailTimeHandler(ITimeRepository bookingTypeRepository)
        {
            this.bookingTypeRepository = bookingTypeRepository;
        }

        public async Task<Result<Time>> Handle(GetDetailTimeQuery request, CancellationToken cancellationToken)
        {
            var entity = await bookingTypeRepository.FindByIdAsync(request.Id, false, true, cancellationToken);
            return Result.Ok(entity);
        }
    }
}