using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.Localizations;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Localizations.Districts
{
    public class GetAllDistrictByProvinceIdQuery : IRequest<Result<List<District>>>
    {
        public string ProvinceId { get; set; }
    }
}