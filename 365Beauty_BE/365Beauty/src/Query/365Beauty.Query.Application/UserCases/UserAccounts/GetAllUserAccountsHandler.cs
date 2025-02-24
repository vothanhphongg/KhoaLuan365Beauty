using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.Queries.UserAccounts;
using _365Beauty.Query.Domain.Abstractions.Repositories.Users;
using _365Beauty.Query.Domain.Entities.Users;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.UserAccounts
{
    public class GetAllUserAccountsHandler : IRequestHandler<GetAllUserAccountsQuery, Result<List<UserAccount>>>
    {
        private readonly IUserAccountRepository userAccountRepository;

        public GetAllUserAccountsHandler(IUserAccountRepository beautySalonServiceRepository)
        {
            this.userAccountRepository = beautySalonServiceRepository;
        }

        public async Task<Result<List<UserAccount>>> Handle(GetAllUserAccountsQuery request, CancellationToken cancellationToken)
        {
            var entity = userAccountRepository.FindAll().ToList();
            return await Task.FromResult(Result.Ok(entity));
        }
    }
}