using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Users;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Users.UserAccounts
{
    public class GetAllStaffAccountQuery : IRequest<Result<List<StaffAccountDTO>>>
{
}
}