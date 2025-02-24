using _365Beauty.Command.Application.DTOs;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Users.UserAccounts
{
    public class LoginUserAccountCommand : IRequest<Result<LoginUserAccountDTOs>>
    {
        public string? Tel { get; set; }
        public string? Password { get; set; }
    }
}