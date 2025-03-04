using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.Queries.Bookings.Times;
using _365Beauty.Query.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Query.Domain.Entities.Bookings;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Bookings.Times
{
    public class GetAllTimeHandler : IRequestHandler<GetAllTimeQuery, Result<List<Time>>>
    {
        private readonly ITimeRepository timeRepository;

        public GetAllTimeHandler(ITimeRepository timeRepository)
        {
            this.timeRepository = timeRepository;
        }

        public async Task<Result<List<Time>>> Handle(GetAllTimeQuery request, CancellationToken cancellationToken)
        {
            var entity = timeRepository.FindAll().ToList();
            return await Task.FromResult(Result.Ok(entity));
        }
    }
}