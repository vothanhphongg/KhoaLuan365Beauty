using _365Beauty.Contract.Enumerations;
using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Users;
using _365Beauty.Query.Domain.Abstractions.Repositories.Users;
using MediatR;
using Queries.Users.UserAccounts;

namespace UserCases.Users.UserAccounts
{
    public class GetAllUserAccountsHandler : IRequestHandler<GetAllUserAccountsQuery, Result<List<UserAccountSimpleDTO>>>
    {
        private readonly IUserAccountRepository userAccountRepository;

        public GetAllUserAccountsHandler(IUserAccountRepository beautySalonServiceRepository)
        {
            userAccountRepository = beautySalonServiceRepository;
        }

        public async Task<Result<List<UserAccountSimpleDTO>>> Handle(GetAllUserAccountsQuery request, CancellationToken cancellationToken)
        {
            var userAccount = userAccountRepository.FindAll(false, x => x.IsActived == StatusActived.Actived, x => x.UserAccountRoles, x => x.UserInformation).Where(x => x.UserAccountRoles.Any(role => role.RoleId == 2)).ToList();
            var entities = userAccount.Select(x => new UserAccountSimpleDTO
            {
                Id = x.Id,
                Tel = x.Tel,
                FullName = $"{x.UserInformation.FirstName} {x.UserInformation.LastName}",
                Img = x.UserInformation.Img,
                Email = x.UserInformation.Email,

            }).ToList();
            return await Task.FromResult(Result.Ok(entities));
        }
    }
}