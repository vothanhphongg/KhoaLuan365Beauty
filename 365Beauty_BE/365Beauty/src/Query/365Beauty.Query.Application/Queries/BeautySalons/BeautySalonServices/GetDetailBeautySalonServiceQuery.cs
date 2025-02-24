using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.BeautySalons;
using MediatR;

namespace _365Beauty.Query.Application.Queries.BeautySalons.BeautySalonServices
{
    public class GetDetailBeautySalonServiceQuery : IRequest<Result<BeautySalonServiceFullDTO>>
    {
        public int Id { get; set; }
    }
}