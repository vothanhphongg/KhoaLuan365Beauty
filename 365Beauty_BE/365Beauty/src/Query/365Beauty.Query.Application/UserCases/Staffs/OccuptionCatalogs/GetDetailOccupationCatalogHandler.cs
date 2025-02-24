using _365Beauty.Contract.Shared;
using _365Beauty.Query.Application.Queries.Staffs.OccuptionCatalogs;
using _365Beauty.Query.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Query.Domain.Entities.Staffs;
using MediatR;

namespace _365Beauty.Query.Application.UserCases.Staffs.OccuptionCatalogs
{
    public class GetDetailOccupationCatalogsHandler : IRequestHandler<GetDetailOccupationCatalogQuery, Result<OccupationCatalog>>
    {
        private readonly IOccupationCatalogRepository occupationCatalogRepository;

        public GetDetailOccupationCatalogsHandler(IOccupationCatalogRepository occupationCatalogRepository)
        {
            this.occupationCatalogRepository = occupationCatalogRepository;
        }

        public async Task<Result<OccupationCatalog>> Handle(GetDetailOccupationCatalogQuery request, CancellationToken cancellationToken)
        {
            var entity = await occupationCatalogRepository.FindByIdAsync(request.Id, false, true, cancellationToken);
            return Result.Ok(entity);
        }
    }
}