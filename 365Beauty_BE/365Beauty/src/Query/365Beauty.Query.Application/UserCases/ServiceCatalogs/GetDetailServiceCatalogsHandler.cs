using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.Queries.ServiceCatalogs;
using _365Beauty.Query.Domain.Abstractions.Repositories.Services;
using _365Beauty.Query.Domain.Entities.Services;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.ServiceCatalogs
{
    public class GetDetailServiceCatalogsHandler : IRequestHandler<GetDetailServiceCatalogQuery, Result<ServiceCatalog>>
    {
        private readonly IServiceCatalogRepository serviceCatalogRepository;

        public GetDetailServiceCatalogsHandler(IServiceCatalogRepository serviceCatalogRepository)
        {
            this.serviceCatalogRepository = serviceCatalogRepository;
        }

        public async Task<Result<ServiceCatalog>> Handle(GetDetailServiceCatalogQuery request, CancellationToken cancellationToken)
        {
            var entity = await serviceCatalogRepository.FindByIdAsync(request.Id, false, true, cancellationToken);
            return Result.Ok(entity);
        }
    }
}