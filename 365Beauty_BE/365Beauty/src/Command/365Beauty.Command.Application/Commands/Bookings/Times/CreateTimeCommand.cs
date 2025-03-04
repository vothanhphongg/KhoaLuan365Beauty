using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Bookings.Times
{
    public class CreateTimeCommand : IRequest<Result<object>>
    {
        public string Times { get; set; }
    }
}