using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Users.UserAccounts
{
    public class CreateStaffAccountCommand : IRequest<Result<object>>
    {
        public int SalonId { get; set; }
    }
}