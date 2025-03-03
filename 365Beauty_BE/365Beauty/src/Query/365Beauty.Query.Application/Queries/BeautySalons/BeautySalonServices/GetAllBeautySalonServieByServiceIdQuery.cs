using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.BeautySalons;
using _365Beauty.Query.Domain.Entities.BeautySalons;
using MediatR;

namespace _365Beauty.Query.Application.Queries.BeautySalons.BeautySalonServices
{
    public class GetAllBeautySalonServieByServiceIdQuery : IRequest<Result<List<BeautySalonServiceWithPriceDTO>>>
    {
        public int ServiceId { get; set; }
    }
}