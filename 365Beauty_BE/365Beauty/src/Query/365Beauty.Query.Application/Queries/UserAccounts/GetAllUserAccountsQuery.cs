using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.Users;
using MediatR;

namespace _365Beauty.Query.Application.Queries.UserAccounts
{
    public class GetAllUserAccountsQuery : IRequest<Result<List<UserAccount>>>
    {
    }
}