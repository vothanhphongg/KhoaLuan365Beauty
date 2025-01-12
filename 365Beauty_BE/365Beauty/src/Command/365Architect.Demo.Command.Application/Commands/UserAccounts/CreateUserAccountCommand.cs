using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.UserAccounts
{
    public class CreateUserAccountCommand : IRequest<Result<object>>
    {
        public string? Tel { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? IdCard { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int? WardId { get; set; }
    }
}