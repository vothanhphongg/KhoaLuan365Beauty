using _365Beauty.Contract.Shared;
using _365Beauty.Query.ApplicationQueries.BeautySalons.BeautySalonCatalogs;
using _365Beauty.Query.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Query.Domain.Entities.BeautySalons;
using MediatR;

namespace UserCases.BeautySalons.BeautySalonCatalogs
{
    public class GetDetailBeautySalonCatalogHandler : IRequestHandler<GetDetailBeautySalonCatalogQuery, Result<BeautySalonCatalog>>
    {
        private readonly IBeautySalonCatalogRepository beautySalonCatalogRepository;

        public GetDetailBeautySalonCatalogHandler(IBeautySalonCatalogRepository beautySalonCatalogRepository)
        {
            this.beautySalonCatalogRepository = beautySalonCatalogRepository;
        }
        public async Task<Result<BeautySalonCatalog>> Handle(GetDetailBeautySalonCatalogQuery request, CancellationToken cancellationToken)
        {
            var entity = await beautySalonCatalogRepository.FindByIdAsync(request.Id, false, true, cancellationToken, includeProperties: x => x.BeautySalonServices);
            return Result.Ok(entity!);
        }
    }
}