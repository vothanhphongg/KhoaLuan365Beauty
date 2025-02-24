using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.Staffs;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Staffs.DegreeCatalogs
{
    public class GetDetailDegreeCatalogQuery : IRequest<Result<DegreeCatalog>>
    {
        public int Id { get; set; }
    }
}