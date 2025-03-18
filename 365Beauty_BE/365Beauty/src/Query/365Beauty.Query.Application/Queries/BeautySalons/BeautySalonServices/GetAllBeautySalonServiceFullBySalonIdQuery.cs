using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.BeautySalons;
using MediatR;

namespace _365Beauty.Query.Application.Queries.BeautySalons.BeautySalonServices
{
    public class GetAllBeautySalonServiceFullBySalonIdQuery : IRequest<Result<List<BeautySalonServiceWithPriceAndBookingDTO>>>
    {
        public int SalonId { get; set; }
    }
}