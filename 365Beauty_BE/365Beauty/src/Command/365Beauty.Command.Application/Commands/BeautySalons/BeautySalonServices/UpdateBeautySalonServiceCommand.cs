using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.BeautySalons.BeautySalonServices
{
    public class UpdateBeautySalonServiceCommand : IRequest<Result<object>>
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
    }
}