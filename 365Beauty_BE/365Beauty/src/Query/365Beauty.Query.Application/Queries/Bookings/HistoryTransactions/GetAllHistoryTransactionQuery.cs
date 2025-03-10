using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.Bookings;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Bookings.HistoryTransactions
{
    public class GetAllHistoryTransactionQuery : IRequest<Result<List<HistoryTransaction>>>
    {
    }
}