using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Users;
using MediatR;

namespace Queries.Users.UserAccounts
{
    public class GetAllUserAccountsQuery : IRequest<Result<List<UserAccountSimpleDTO>>>
    {
    }
}