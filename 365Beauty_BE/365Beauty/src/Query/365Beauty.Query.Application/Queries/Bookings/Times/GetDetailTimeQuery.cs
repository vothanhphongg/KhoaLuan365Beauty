using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.Bookings;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Bookings.Times
{
    public class GetDetailTimeQuery : IRequest<Result<Time>>
    {
        public int Id { get; set; }
    }
}