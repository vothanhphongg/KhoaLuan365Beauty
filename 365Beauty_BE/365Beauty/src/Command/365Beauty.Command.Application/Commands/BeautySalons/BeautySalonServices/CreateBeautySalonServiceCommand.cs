using _365Beauty.Command.Application.DTOs;
using _365Beauty.Contract.Shared;
using MediatR;

namespace _365Beauty.Command.Application.Commands.BeautySalons.BeautySalonServices
{
    public class CreateBeautySalonServiceCommand : IRequest<Result<object>>
    {
        public int SalonId { get; set; }
        public List<BeautySalonServiceDTOs>? BeautySalonServices { get; set; }
    }
}