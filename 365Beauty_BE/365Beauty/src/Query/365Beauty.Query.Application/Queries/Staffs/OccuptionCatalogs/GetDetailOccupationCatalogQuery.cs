using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.Staffs;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Staffs.OccuptionCatalogs
{
    public class GetDetailOccupationCatalogQuery : IRequest<Result<OccupationCatalog>>
    {
        public int Id { get; set; }
    }
}