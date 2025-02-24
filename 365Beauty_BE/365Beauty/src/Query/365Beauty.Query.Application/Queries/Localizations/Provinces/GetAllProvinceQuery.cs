using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.Localizations;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Localizations.Provinces
{
    public class GetAllProvinceQuery : IRequest<Result<List<Province>>>
    {
    }
}