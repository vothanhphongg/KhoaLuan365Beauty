using _365Beauty.Contract.Shared;
using _365Beauty.Query.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Query.Domain.Entities.Staffs;
using MediatR;

namespace _365Beauty.Query.Application.Queries.Staffs.OccuptionCatalogs
{
    public class GetAllOccupationCatalogHandler : IRequestHandler<GetAllOccupationCatalogQuery, Result<List<OccupationCatalog>>>
    {
        private readonly IOccupationCatalogRepository occupationCatalogRepository;

        public GetAllOccupationCatalogHandler(IOccupationCatalogRepository occupationCatalogRepository)
        {
            this.occupationCatalogRepository = occupationCatalogRepository;
        }

        public async Task<Result<List<OccupationCatalog>>> Handle(GetAllOccupationCatalogQuery request, CancellationToken cancellationToken)
        {
            var entity = occupationCatalogRepository.FindAll().ToList();
            return await Task.FromResult(Result.Ok(entity));
        }
    }
}