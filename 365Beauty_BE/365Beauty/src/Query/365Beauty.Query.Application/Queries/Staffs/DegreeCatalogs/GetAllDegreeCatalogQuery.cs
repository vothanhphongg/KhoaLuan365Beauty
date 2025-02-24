using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.Staffs;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Staffs.DegreeCatalogs
{
    public class GetAllDegreeCatalogQuery : IRequest<Result<List<DegreeCatalog>>>
    {
    }
}