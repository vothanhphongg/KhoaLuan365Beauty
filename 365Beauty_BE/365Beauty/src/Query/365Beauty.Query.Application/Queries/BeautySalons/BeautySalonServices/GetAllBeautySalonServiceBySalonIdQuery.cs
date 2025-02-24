using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.BeautySalons;
using MediatR;

namespace _365Beauty.Query.Application.Queries.BeautySalons.BeautySalonServices
{
    public class GetAllBeautySalonServiceBySalonIdQuery : IRequest<Result<List<BeautySalonService>>>
    {
        public int SalonId { get; set; }
        public int IsActived { get; set; }
    }
}