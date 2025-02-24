using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.Localizations;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Localizations.Wards
{
    public class GetAllWardByDistrictIdQuery : IRequest<Result<List<Ward>>>
    {
        public string DistrictId { get; set; }
    }
}