using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.Services;
using MediatR;

namespace _365Beauty.Query.Application.Queries.ServiceCatalogs
{
    public class GetDetailServiceCatalogQuery : IRequest<Result<ServiceCatalog>>
    {
        public int Id { get; set; }
    }
}