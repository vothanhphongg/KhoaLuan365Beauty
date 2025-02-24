using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.Localizations;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Localizations.Provinces
{
    public class GetDetailProvinceQuery : IRequest<Result<Province>>
    {
        public string Id { get; set; }
    }
}