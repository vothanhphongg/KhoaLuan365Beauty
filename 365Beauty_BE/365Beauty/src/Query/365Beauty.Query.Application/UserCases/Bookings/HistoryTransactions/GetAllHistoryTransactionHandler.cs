using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.Queries.Bookings.HistoryTransactions;
using _365Beauty.Query.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Query.Domain.Entities.Bookings;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Bookings.HistoryTransactions
{
    public class GetAllHistoryTransactionHandler : IRequestHandler<GetAllHistoryTransactionQuery, Result<List<HistoryTransaction>>>
    {
        private readonly IHistoryTransactionRepository historyTransactionRepository;

        public GetAllHistoryTransactionHandler(IHistoryTransactionRepository historyTransactionRepository)
        {
            this.historyTransactionRepository = historyTransactionRepository;
        }
        public async Task<Result<List<HistoryTransaction>>> Handle(GetAllHistoryTransactionQuery request, CancellationToken cancellationToken)
        {
            var entity = historyTransactionRepository.FindAll().ToList();
            return await Task.FromResult(Result.Ok(entity));
        }
    }
}