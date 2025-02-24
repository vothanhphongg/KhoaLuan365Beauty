using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.BeautySalons.BeautySalonServices
{
    public class LockOrUnLockBeautySalonServiceCommand : IRequest<Result<object>>
    {
        public int Id { get; set; }
    }
}