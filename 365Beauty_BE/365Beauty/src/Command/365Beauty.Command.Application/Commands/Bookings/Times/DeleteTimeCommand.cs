using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.Bookings.Times
{
    public class DeleteTimeCommand : IRequest<Result<object>>
    {
        public int Id { get; set; }
    }
}