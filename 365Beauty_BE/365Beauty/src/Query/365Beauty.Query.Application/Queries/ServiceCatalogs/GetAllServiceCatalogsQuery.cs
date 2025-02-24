using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Entities.Services;
using MediatR;

namespace _365Beauty.Query.Application.Queries.ServiceCatalogs
{
    public class GetAllServiceCatalogsQuery : IRequest<Result<List<ServiceCatalog>>>
    {
        public int IsActived { get; set; }
    }
}