using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.Localizations;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Localizations.Districts
{
    public class GetDetailDistrictQuery : IRequest<Result<District>>
    {
        public string Id { get; set; }
    }
}