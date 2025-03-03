using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.DTOs.Services;
using MediatR;

namespace _365Beauty.Query.Application.Queries.ServiceCatalogs
{
    public class GetAllServiceCatalogWithCountQuery : IRequest<Result<List<ServiceCatalogWithCount>>>
    {
    }
}